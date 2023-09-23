using System;
using System.Collections.Generic;
using Code.Block;
using Code.HUD;
using Code.Pools;
using UnityEngine;

namespace Code.Main
{
    [DisallowMultipleComponent]
    public class EntryPoint : MonoBehaviour
    {
        [field: SerializeField] public BlockSpawnerSettings BlockSpawnerSettings { get; private set; }
        [field: SerializeField] public ScreenService ScreenServiceList { get; private set; }
        [field: SerializeField] public PoolCommonParent PoolCommonParent { get; private set; }

        private void Awake()
        {
            BlockSpawner.Initialize(BlockSpawnerSettings, PoolCommonParent);

        }
    }
}