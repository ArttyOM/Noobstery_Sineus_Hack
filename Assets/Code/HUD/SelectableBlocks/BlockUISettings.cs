using System;
using Code.Block;
using TMPro;
using UnityEngine;

namespace Code.HUD.SelectableBlocks
{
    [DisallowMultipleComponent]
    public class BlockUISettings : MonoBehaviour
    {
         [field: SerializeField] public BlockUIConfig BlockConfig { get; private set; }

         private void Awake()
         {
             BlockConfig.PriceBlockText.text = BlockConfig.PriceBlock.ToString();
         }
    }
}