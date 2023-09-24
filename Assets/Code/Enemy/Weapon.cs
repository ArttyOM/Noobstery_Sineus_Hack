using System;
using System.Collections.Generic;
using System.Threading;
using Code.DebugTools.Logger;
using Code.Pools;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Code.Enemy
{
    /// <summary>
    /// оружие умеет спаунить свои патроны с некоторой частотой.
    /// оружие может разряжаться
    /// </summary>
    public class Weapon : MonoBehaviour, IDisposable
    {
        [SerializeField] private float fireInterval = 1f;
        [SerializeField] private int initialAmmoCapasity = 4;
        [SerializeField] public float switchTime = 3f;
        [SerializeField] public BulletMarker bulletPrefab;
        [SerializeField] private Transform spawnTransform;
        
        private CancellationTokenSource token;
        private ReactiveProperty<int> ammoCapasityObservable;
        private ObjectPool<BulletMarker> pool;
        public List<BulletMarker> activeBullets = new List<BulletMarker>();
        
        
        public ReactiveProperty<int> AmmoCapasityObservable => ammoCapasityObservable;

        private void Awake()
        {
            token = new CancellationTokenSource();
            pool = new ObjectPool<BulletMarker>(bulletPrefab, null, 30, InitPool);
        }

        private void InitPool(BulletMarker bulletMarker)
        {
        }
        
        public void StartFiring()
        {
            ammoCapasityObservable = new ReactiveProperty<int>(initialAmmoCapasity);

            Observable.Interval(TimeSpan.FromSeconds(fireInterval))
                .TakeWhile(_ => ammoCapasityObservable.Value > 0)
                .Subscribe(x =>
                {
                    ammoCapasityObservable.Value--;
                    Fire();
                });
        }

        private async void Fire()
        {
            $"{this.name} is firing".Colored(Color.red).Log();
            var newBullet = pool.GetObject(spawnTransform.position, Quaternion.identity);
            activeBullets.Add(newBullet);
            await UniTask.Delay(TimeSpan.FromSeconds(5), cancellationToken:token.Token);
            
            pool.ReturnObject(newBullet);
            activeBullets.Remove(newBullet);
        }

        public void Dispose()
        {
            token.Dispose();
        }
    }
}
