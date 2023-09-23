using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Block
{
    [Serializable]
    public class BlockConfig
    {
        [field: SerializeField] public String Name { get; private set; }
        [field: SerializeField] public BlockType Type { get; private set; }
        [field: SerializeField] public Sprite Image { get; private set; }
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public int Price { get; private set; }
    }
}