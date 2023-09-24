using System;
using Code.Block;
using TMPro;
using UnityEngine;

namespace Code.HUD.SelectableBlocks
{
    [Serializable]
    public class BlockUIConfig
    {
        [field: SerializeField] public TextMeshProUGUI PriceBlockText { get; private set; }
        [field: SerializeField] public BlockType SpawnTypeBlock { get; private set; }
        [field: SerializeField] public int PriceBlock { get; private set; }
    }
}