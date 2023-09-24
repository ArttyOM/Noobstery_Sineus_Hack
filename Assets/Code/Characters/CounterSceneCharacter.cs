using System.Collections.Generic;
using Code.DebugTools.Logger;
using Code.GameLogic;
using Code.HUD.CharacterCounter;
using TMPro;
using UniRx;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Characters
{
    public class CounterSceneCharacter
    {
        private readonly List<HitPoints> _hitPoints;
        private readonly CharacterCount _characterCount;
        private int _countCharacters;

        public CounterSceneCharacter(TextMeshProUGUI textMeshProUGUI, CharacterMarker[] character)
        {
            _hitPoints = new List<HitPoints>();
            var character1 = character;
            _characterCount = new CharacterCount(textMeshProUGUI, character1.Length);

            for (int i = 0; i < character1.Length; i++)
            {
                _hitPoints.Add(character1[i].HitPoints);
                _countCharacters++;
            }

            foreach (var hitPoint in _hitPoints)
            {
                hitPoint.ObservableDeadStatus
                    .Where(x => x == HitPoints.DamagedStatus.DEAD)
                    .Subscribe(_ => ReductionLiveCharacters(hitPoint));
            }
        }
        
        public CharacterCount CharacterCount => _characterCount;
        
        private void ReductionLiveCharacters(HitPoints hitPoints)
        {
            _hitPoints.Remove(hitPoints);
            _characterCount.ChangeCounter(_hitPoints.Count);
            _countCharacters--;
        }
    }
}