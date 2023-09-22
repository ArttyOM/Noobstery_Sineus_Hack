using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Block
{
    [System.Serializable]
    public class BlockConfig
    {
        [field: SerializeField] public String Name { get; private set; }
        [field: SerializeField] public BlockType Type { get; private set; }
        [field: SerializeField] public Image Image { get; private set; }
        [field: SerializeField] public int Health { get; private set; }
    }
}