using System.Collections.Generic;
using Code.Pools;
using UnityEngine;

namespace Code.Block
{
    public class BlockSpawner
    {
        private readonly BlockSpawnerSettings _blockSpawnerSettings;
        private readonly PoolCommonParent _poolCommonParent;
        private Dictionary<BlockType, ObjectPool<Collider2D>> _pools;
        public BlockSpawner(BlockSpawnerSettings blockSpawnerSettings, PoolCommonParent poolCommonParent)
        {
            _blockSpawnerSettings = blockSpawnerSettings;
            _poolCommonParent = poolCommonParent;
            CreatePoolsBlocks();
        }

        private void CreatePoolsBlocks()
        {
            for (int i = 0; i < _blockSpawnerSettings.Configs.Count; i++)
            {
                if (_pools.ContainsKey(_blockSpawnerSettings.Configs[i].Type)) return;
                var block = _blockSpawnerSettings.DefaultSpawnObject;
                var tempPool = new ObjectPool<Collider2D>(block, _poolCommonParent.transform, 15,
                    initPool: InitPool);
                _pools.Add(_blockSpawnerSettings.Configs[i].Type, tempPool);
            }
        }
        
        private static void InitPool(Collider2D collider2D)
        {
            //collider2D.gameObject.name = 
        }
    }
}