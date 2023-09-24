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


            for (int i = 0; i < TimerTexts.Count; i++)
            {
                if (i == 0)
                {
                    _stringBuilder.Clear();
                    _stringBuilder.Append(seconds);
                    TimerTexts[i].text = _stringBuilder.ToString();
                }
                
                else
                {
                    _stringBuilder.Clear();
                    _stringBuilder.Append("Вы продержались ");
                    _stringBuilder.Append(seconds);
                    _stringBuilder.Append(" секунд");
                    TimerTexts[i].text = _stringBuilder.ToString();
                }
                
            }
        }
    }
}