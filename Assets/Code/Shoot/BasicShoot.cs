using UnityEngine;
using Code.Pools;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using System.Collections.Generic;
using UniRx;
using UnityEngine.Serialization;
using Code.Enemy;

public class BulletSpawner : MonoBehaviour, IDisposable
{
    [SerializeField] private Transform spawnTransform;
    [SerializeField] public BulletMarker bullet;
    [SerializeField] private float force;
    private List<BulletMarker> activeBullets = new List<BulletMarker>();
    private ObjectPool<BulletMarker> pool;
    private CancellationTokenSource token;

    private void Awake()
    {
        pool = new ObjectPool<BulletMarker>(bullet, null, 30, InitPool);
        token = new CancellationTokenSource();
        
  
    }

    private void InitPool(BulletMarker collider)
    {
    }

    // private void Update()
    // {
    //     if (Input.GetMouseButtonDown(0)) 
    //     {
    //         Shot();
    //     }
    // }

    private async void Shot()
    {
        var newBullet = pool.GetObject(spawnTransform.position, Quaternion.identity);
        var bulletRigidbody = newBullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.AddForce(spawnTransform.right.normalized * force);
        activeBullets.Add(newBullet);
        await UniTask.Delay(TimeSpan.FromSeconds(5), cancellationToken:token.Token);
        bulletRigidbody.velocity = new Vector3(0f,0f,0f);
        pool.ReturnObject(newBullet);
        activeBullets.Remove(newBullet);
    }

    private void SpawnBullet()
    {
        
    }

    public void Dispose()
    {
        token.Dispose();
    }
}
