using System;
using UniRx;
using UnityEngine;

namespace Code.GameLogic
{
    public class HitPoints : MonoBehaviour
    {
        [SerializeField] private float _maxHP = 100f;

        private ReactiveProperty<float> _reactiveCurrentHP;
        
        public IObservable<float> ObservableCurrentHP => _reactiveCurrentHP;

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
            float sum = _reactiveCurrentHP.Value + value;
            if (sum > _maxHP )
            {
                _reactiveCurrentHP.Value = _maxHP;
            }
            else if (sum <= 0f)
            {
                _reactiveCurrentHP.Value = 0f;
            }
            _reactiveCurrentHP.Value += value;
        }
        
        private void Awake()
        {
            _reactiveCurrentHP = new ReactiveProperty<float>(_maxHP);
        }
    }
}
