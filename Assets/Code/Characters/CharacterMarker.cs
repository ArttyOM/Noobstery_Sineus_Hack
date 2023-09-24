using System;
using Code.GameLogic;
using UnityEngine;

namespace Code.Characters
{
    [DisallowMultipleComponent]
    public class CharacterMarker : MonoBehaviour
    {
        [field: SerializeField] public HitPoints HitPoints { get; private set; }
    }
}