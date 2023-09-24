using System;
using System.Threading;
using Code.DebugTools.Logger;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;


namespace Code.Enemy
{
    public class Shooter : MonoBehaviour, IDisposable
    {
        [SerializeField] private GameObject weaponsParent;

        [SerializeField] private float initDelay = 3f;
        
        private CancellationTokenSource token;
        
        private void Awake()
        {
            token = new CancellationTokenSource();
            
        }


        private async void Start()
        {
            var weapons = weaponsParent.GetComponentsInChildren<Weapon>();
            
            await UniTask.Delay(TimeSpan.FromSeconds(initDelay), cancellationToken:token.Token);

            for (int i = 0; ; i++)
            {
                if (i >= weapons.Length) i = 0;
                
                $"current weapon is {weapons[i].name}".Colored(Color.red).Log();
                weapons[i].StartFiring();

                await UniTask
                    .WaitUntil(() => CheckIsAmmoEmpty(weapons[i].AmmoCapasityObservable),
                        cancellationToken:token.Token);
                    
                await UniTask.Delay(TimeSpan.FromSeconds(weapons[i].switchTime), cancellationToken:token.Token);
            }
        }

        private bool CheckIsAmmoEmpty(ReactiveProperty<int> AmmoCapasityObservable)
        {
            return (AmmoCapasityObservable.Value <= 0);
        }
        
        public void Dispose()
        {
            token.Dispose();
        }
    }
}
