using UnityEngine;
using Code.Pools;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;

public class BulletSpawner : MonoBehaviour, IDisposable
{
    [SerializeField] private Transform spawnTransform;
    [SerializeField] private Collider2D bullet;
    [SerializeField] private float force;
    private ObjectPool<Collider2D> pool;
    private CancellationTokenSource token;

    private void Awake()
    {
        pool = new ObjectPool<Collider2D>(bullet, null, 30, InitPool);
        token = new CancellationTokenSource();
    }

    private void InitPool(Collider2D collider)
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
        newBullet.GetComponent<Rigidbody2D>().AddForce(spawnTransform.right.normalized * force);
        await UniTask.Delay(TimeSpan.FromSeconds(5), cancellationToken:token.Token);
        pool.ReturnObject(newBullet);
    }

    public void Dispose()
    {
        token.Dispose();
    }
}
