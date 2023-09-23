using System;
using UniRx;
using UnityEngine;

namespace Code.GameLogic
{
    public class BlockDeathHandler : MonoBehaviour
    {
        [SerializeField] private HitPoints _hitPoints;
        private IDisposable _deadStatusSubscription;
        
        private void Start()
        {
            _deadStatusSubscription = _hitPoints.ObservableDeadStatus.Where(x => x == HitPoints.DamagedStatus.DEAD)
                .Subscribe(_=>DestroyBlock());
        }

        private void OnDestroy()
        {
            _deadStatusSubscription?.Dispose();
        }

        private void DestroyBlock()
        {
            this.gameObject.SetActive(false);
        }
    }
}
