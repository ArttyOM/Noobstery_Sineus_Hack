using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

namespace Code.HUD.GameTimer
{
    public class Timer : MonoBehaviour
    {
        [field: SerializeField] public List<TextMeshPro> TimerTexts { get; private set; }
        private StringBuilder _stringBuilder;
        private float _currentTime;
        private void Awake()
        {
            TimerTexts = new List<TextMeshPro>();
            _stringBuilder = new StringBuilder();
        }

        private void Update()
        {
            Countdown();
        }

        private void Countdown()
        {
                            
            _currentTime -= Time.deltaTime;

            int seconds = Mathf.FloorToInt(_currentTime);
            foreach (var timerText in TimerTexts)
            {
                _stringBuilder.Clear();
                _stringBuilder.Append(seconds);
                timerText.text = _stringBuilder.ToString();
            }
            
        }
    }
}