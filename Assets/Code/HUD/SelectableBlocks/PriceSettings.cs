using TMPro;
using UnityEngine;

namespace Code.HUD.SelectableBlocks
{
    public class PriceSettings : MonoBehaviour
    {
        [field: SerializeField] public TextMeshProUGUI ResourcesText { get; private set; }
        [field: SerializeField] public int StartResources { get; private set; }
    }
}