using System;
using Code.GameLogic;
using UnityEngine;

namespace Code.Characters
{
    [DisallowMultipleComponent]
    public class CharacterMarker : MonoBehaviour
    {
        public HitPoints HitPoints { get; private set; }

        private void Awake()
        {
            HitPoints = GetComponent<HitPoints>();
        }
    }
}