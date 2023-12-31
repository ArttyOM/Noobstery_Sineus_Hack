﻿using System.Collections.Generic;
using UnityEngine;

namespace Code.Block
{
    [DisallowMultipleComponent]
    public class BlockSpawnerSettings : MonoBehaviour
    {
        [field: SerializeField] public BlockSettings DefaultSpawnObject { get; private set; }
        [field: SerializeField] public List<BlockConfig> Configs { get; private set; }
    }
}