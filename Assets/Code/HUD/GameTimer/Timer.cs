using System;
using System.Collections.Generic;
using System.Text;
using Code.DebugTools.Logger;
using TMPro;
using UnityEngine;

namespace Code.HUD.GameTimer
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private List<TextMeshProUGUI> TimerTexts;
        private StringBuilder _stringBuilder;
        private float _currentTime;
        private void Awake()
        {
            _stringBuilder = new StringBuilder();
        }

        private void Update()
        {
            Countdown();
        }

        private void Countdown()
        {
            _currentTime += Time.deltaTime;
            int seconds = Mathf.FloorToInt(_currentTime);
            _stringBuilder.Clear();
            _stringBuilder.Append(seconds);
            
            foreach (var timerText in TimerTexts)
            {
                timerText.text = _stringBuilder.ToString();
            }
        }
    }
}