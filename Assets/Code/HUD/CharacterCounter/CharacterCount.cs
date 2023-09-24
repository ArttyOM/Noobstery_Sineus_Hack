using System;
using System.Text;
using TMPro;
using UniRx;
using UnityEngine;

namespace Code.HUD.CharacterCounter
{
    public class CharacterCount
    {
        private Subject<bool> _onGameOver = new Subject<bool>();

        private readonly TextMeshProUGUI _textMeshProUGUI;
        private readonly StringBuilder _stringBuilder;
        private readonly int _maxCount;

        public IObservable<bool> OnGameOver => _onGameOver;

        public CharacterCount(TextMeshProUGUI textMeshProUGUI, int maxCount)
        {
            _maxCount = maxCount;
            _textMeshProUGUI = textMeshProUGUI;
            _stringBuilder = new StringBuilder();
            ChangeCounter(_maxCount);
        }

        public void ChangeCounter(int currentCount)
        {
            _stringBuilder.Clear();
            _stringBuilder.Append(currentCount);
            _stringBuilder.Append(" / ");
            _stringBuilder.Append(_maxCount);
            _textMeshProUGUI.text = _stringBuilder.ToString();
            GameOver(currentCount);
        }

        private void GameOver(int currentCount)
        {
            if (currentCount <= 0)
            {
                Time.timeScale = 0;
                ScreenSwitcher.ShowScreen(ScreenType.Defeat);
                _onGameOver.OnNext(true);
            }
        }
    }
}