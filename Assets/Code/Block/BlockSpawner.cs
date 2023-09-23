using System.Collections.Generic;
using Code.DebugTools.Logger;
using Code.Pools;
using UnityEngine;

namespace Code.Block
{
    public static class BlockSpawner
    {
        private static BlockSpawnerSettings _blockSpawnerSettings;
        private static PoolCommonParent _poolCommonParent;
        private static Dictionary<BlockType, ObjectPool<BlockSettings>> _pools;
        public static void Initialize(BlockSpawnerSettings blockSpawnerSettings, PoolCommonParent poolCommonParent)
        {
            _blockSpawnerSettings = blockSpawnerSettings;
            _poolCommonParent = poolCommonParent;
            _pools = new Dictionary<BlockType, ObjectPool<BlockSettings>>();
            CreatePoolsBlocks();
        }

        private static void CreatePoolsBlocks()
        {
            for (int i = 0; i < _blockSpawnerSettings.Configs.Count; i++)
            {
                if (_pools.ContainsKey(_blockSpawnerSettings.Configs[i].Type)) return;
                var block = _blockSpawnerSettings.DefaultSpawnObject;
                var tempPool = new ObjectPool<BlockSettings>(block, _poolCommonParent.transform, 15,
                    initPool: InitPool);
                
                _pools.Add(_blockSpawnerSettings.Configs[i].Type, tempPool);
            }
        }
        
        private static void InitPool(BlockSettings blockSettings)
        {
            
        }

        public static BlockSettings GetBlock(BlockType type, Vector3 position)
        {
            var pool = _pools[type];
            BlockSettings receivedBlock = null;
            foreach (var config in  _blockSpawnerSettings.Configs)
            {
                if (type == config.Type)
                {
                    receivedBlock = pool.GetObject(position, Quaternion.identity);
                    receivedBlock.name = config.Name;
                    receivedBlock.SetType(config.Type);
                    receivedBlock.SetImage(config.Image);
                    receivedBlock.SetPrice(config.Price);
                    receivedBlock.SetHealth(config.Health);
                }
            }
            
            return receivedBlock;
        }

        public static void ReturnToPool(BlockSettings blockSettings)
        {
            var pool = _pools[blockSettings.Type];
            pool.ReturnObject(blockSettings);
        }
    }
}