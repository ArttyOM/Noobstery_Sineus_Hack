using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Code.GameLogic
{
    public class DamageVisualizer : MonoBehaviour
    {
        [SerializeField] private HitPoints _hitPoints;
        //public HitPoints.DamagedStatus Status;
        [SerializeField] private List<HitPointsToDamageVisualPair> hitPointsToDamageVisualList = new List<HitPointsToDamageVisualPair>();

        private IDisposable _onHpChangedSubscription;
        
        private void Start()
        {
            _onHpChangedSubscription = _hitPoints.ObservableCurrentHP.Subscribe(OnHpChanged);
        }

        private void OnDestroy()
        {
            _onHpChangedSubscription?.Dispose();
        }

        private void OnHpChanged(float newHp)
        {
            foreach (var hitPointToDamageVisual in hitPointsToDamageVisualList)
            {
                if (newHp <= hitPointToDamageVisual.hitPointsLessOrEqualThan)
                {
                    hitPointToDamageVisual.damageVisual.SetActive(true);
                }
                else hitPointToDamageVisual.damageVisual.SetActive(false);
            }
        }
    }
}
