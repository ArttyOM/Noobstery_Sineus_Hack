using System;
using UniRx;
using UnityEngine;

namespace Code.GameLogic
{
    /// <summary>
    /// Отвечает за уменьшение числовых показателей здоровья
    /// </summary>
    [RequireComponent(typeof(HitPoints))]
    public class DamageReceiver : MonoBehaviour
    {
        [SerializeField] private AnimationCurve damageForceConverter;
        [SerializeField] private bool _shouldLogDamageCalculating = true;
        
        private HitPoints _hitPoints;
        
        private IObservable<Collision2D> _damageReceiverObservable;
        private IDisposable _onReceivedDamageSubscription;
        
        private void Awake()
        {
            _hitPoints = GetComponent<HitPoints>();

            _damageReceiverObservable = InitDamageReceiverObservable();
            _onReceivedDamageSubscription = _damageReceiverObservable
                .Subscribe(DecreaseHPOnCollision2d);
        }
        
        private void OnDestroy()
        {
            _onReceivedDamageSubscription?.Dispose();
        }

        /// <summary>
        /// Собирает в общий поток события всех дочерних DamageableMarker-ов 
        /// </summary>
        private IObservable<Collision2D> InitDamageReceiverObservable()
        {
            var damageableParts = GetComponentsInChildren<DamageableMarker>();
            if (damageableParts.Length == 0) Debug
                .LogError("В дочерних объектах не обнаружены DamageableMarker: некому обрабатывать коллизии для получения урона");
            IObservable<Collision2D> damageReceiverObservable = null;
            foreach (var damageablePart in damageableParts)
            {
                if (damageReceiverObservable is null)
                {
                    damageReceiverObservable = damageablePart.GetCollision2DEnterAsObservable();
                }
                else {
                    damageReceiverObservable
                        .Merge(damageablePart.GetCollision2DEnterAsObservable());
                }
            }

            return damageReceiverObservable;
        }

 

        private void DecreaseHPOnCollision2d(Collision2D collision2D)
        {
            float damageValue = CalculateDamageValue(collision2D);
            if (damageValue <= 0)
                return;

            DecreaseHp(damageValue);
        }

        private void DecreaseHp(float damageValue)
        {
            if (damageValue < 0)
            {
                Debug.LogError($"damageValue = {damageValue} должен быть больше нуля");
                return;
            }

            _hitPoints.ChangeHP(-damageValue);
        }
        
        /// <summary>
        /// По графику забираем показатель урона в зависимости от скорости и массы врезавшегося объекта
        /// </summary>
        /// <param name="collision2D">
        /// нужен для расчёта скорости столкновения</param>
        /// <returns></returns>
        private float CalculateDamageValue(Collision2D collision2D)
        {
            float receivedDoubledKineticEnergy = collision2D.relativeVelocity.sqrMagnitude * collision2D.otherRigidbody.mass;
            float damage = damageForceConverter.Evaluate(receivedDoubledKineticEnergy);
            if (_shouldLogDamageCalculating)
            {
                Debug.Log($"receivedDoubledKineticEnergy = {receivedDoubledKineticEnergy}");
                Debug.Log($"damage = {damage}");
            }

            return damage;
        }
        
    }
}
