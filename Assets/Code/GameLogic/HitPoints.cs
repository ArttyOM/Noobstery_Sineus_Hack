using System;
using UniRx;
using UnityEngine;

namespace Code.GameLogic
{
    public class HitPoints : MonoBehaviour
    {
        public enum DamagedStatus
        {
            NOT_DAMAGED,
            DAMAGED,
            DEAD
        }
        
        [SerializeField] private float _maxHP = 100f;

        private ReactiveProperty<float> _reactiveCurrentHP;
        private Subject<DamagedStatus> _observableDamagedStatus = new Subject<DamagedStatus>();

        public IObservable<float> ObservableCurrentHP => _reactiveCurrentHP;
        
        /// <summary>
        /// в ивенте true = мертв
        /// false = перестал быть мертвым
        /// </summary>
        public IObservable<DamagedStatus> ObservableDeadStatus => _observableDamagedStatus;

        /// <summary>
        /// Смена состояния ХП.
        /// При увеличении - не больше максимального запаса.
        /// При уменьшении - не меньше нуля.
        /// </summary>
        /// <param name="value">
        /// отрицательное значение отнимет ХП
        /// положительное - прибавит
        /// </param>
        public void ChangeHP(float value)
        {
            float newHpValue = _reactiveCurrentHP.Value + value;
            float currentHpValue = _reactiveCurrentHP.Value;

            if (newHpValue > _maxHP )
            {
                if (currentHpValue <= _maxHP)
                {
                    _reactiveCurrentHP.Value = _maxHP;
                    _observableDamagedStatus.OnNext(DamagedStatus.NOT_DAMAGED);
                }
            }
            else if (newHpValue <= 0f)
            {
                if (currentHpValue > 0f)
                {
                    _reactiveCurrentHP.Value = 0f;
                    _observableDamagedStatus.OnNext(DamagedStatus.DEAD);
                }
            }
            else
            {
                if (currentHpValue <= 0 || currentHpValue > _maxHP) 
                {
                    _observableDamagedStatus.OnNext(DamagedStatus.DAMAGED);
                }
                _reactiveCurrentHP.Value += value;
            }
            
        }
        
        private void Awake()
        {
            _reactiveCurrentHP = new ReactiveProperty<float>(_maxHP);
        }
    }
}
