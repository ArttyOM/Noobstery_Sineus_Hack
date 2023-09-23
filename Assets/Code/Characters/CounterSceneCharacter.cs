using System;
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

        public CounterSceneCharacter(TextMeshProUGUI textMeshProUGUI)
        {
            _hitPoints = new List<HitPoints>();
            var characters = Object.FindObjectsOfType<CharacterMarker>();
            _characterCount = new CharacterCount(textMeshProUGUI, characters.Length);
            _countCharacters = characters.Length;
            
            for (int i = 0; i < characters.Length; i++)
            {
                _hitPoints.Add(characters[i].HitPoints);
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