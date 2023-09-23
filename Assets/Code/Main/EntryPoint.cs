using System;
using Code.Block;
using Code.Pools;
using UnityEngine;

namespace Code.Main
{
    [DisallowMultipleComponent]
    public class EntryPoint : MonoBehaviour
    {
        [field: SerializeField] public BlockSpawnerSettings BlockSpawnerSettings { get; private set; }
        [field: SerializeField] public PoolCommonParent PoolCommonParent { get; private set; }

        private void Awake()
        {
            BlockSpawner.Initialize(BlockSpawnerSettings, PoolCommonParent);

        }
    }
}