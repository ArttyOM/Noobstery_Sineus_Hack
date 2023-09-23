using System;
using System.Collections.Generic;
using Code.DebugTools.Logger;
using Code.GameLogic;
using UniRx;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Characters
{
    public class CounterSceneCharacter
    {
        private readonly List<HitPoints> _hitPoints;
        public int CountCharacters { get; private set; }

        public CounterSceneCharacter()
        {
            _hitPoints = new List<HitPoints>();
            var characters = Object.FindObjectsOfType<CharacterMarker>();

            for (int i = 0; i < characters.Length; i++)
            {
                characters[i].HitPoints.ObservableDeadStatus
                    .Where(x => x == HitPoints.DamagedStatus.DEAD)
                    .Subscribe(_ => ReductionLiveCharacters());
                
                IncreaseInLiveCharacters();
                _hitPoints.Add(characters[i].HitPoints);
            }
        }

        public void IncreaseInLiveCharacters()
        {
            CountCharacters++;
        }

        public void ReductionLiveCharacters()
        {
            $"11111111111111".Colored(Color.cyan).Log();
            CountCharacters--;
        }
    }
}