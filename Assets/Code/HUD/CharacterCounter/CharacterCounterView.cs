using TMPro;
using UnityEngine;

namespace Code.HUD.CharacterCounter
{
    public class CharacterCounterView : MonoBehaviour
    {
        [field: SerializeField] public TextMeshProUGUI CounterText { get; private set; }
    }
}