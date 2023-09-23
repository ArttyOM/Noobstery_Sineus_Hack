using UnityEngine;
using Code.Pools;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using System.Collections.Generic;

public class BulletSpawner : MonoBehaviour, IDisposable
{
    [SerializeField] private Transform spawnTransform;
    [SerializeField] public BulletSettings bullet;
    [SerializeField] private float force;
    public List<BulletSettings> settings = new List<BulletSettings>();
    private ObjectPool<BulletSettings> pool;
    private CancellationTokenSource token;

    private void Awake()
    {
        pool = new ObjectPool<BulletSettings>(bullet, null, 30, InitPool);
        token = new CancellationTokenSource();
    }

    private void InitPool(BulletSettings collider)
    {
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Shot();
        }
    }

    private async void Shot()
    {
        var newBullet = pool.GetObject(spawnTransform.position, Quaternion.identity);
        var bulletRigidbody = newBullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.AddForce(spawnTransform.right.normalized * force);
        settings.Add(newBullet);
        await UniTask.Delay(TimeSpan.FromSeconds(5), cancellationToken:token.Token);
        bulletRigidbody.velocity = new Vector3(0f,0f,0f);
        pool.ReturnObject(newBullet);
        settings.Remove(newBullet);
    }

    public void Dispose()
    {
        token.Dispose();
    }
}
