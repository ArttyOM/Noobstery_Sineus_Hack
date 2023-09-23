using UnityEngine;
using UnityEngine.Serialization;

namespace Code.GameLogic
{
    [System.Serializable]
    public struct HitPointsToDamageVisualPair
    {
        [FormerlySerializedAs("hitPointsLessThan")] public float hitPointsLessOrEqualThan;
        public GameObject damageVisual;
    }
}