using System;
using System.Collections.Generic;
using Code.Block;
using Code.Characters;
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
        private CounterSceneCharacter _counterSceneCharacter;

        private void Awake()
        {
            BlockSpawner.Initialize(BlockSpawnerSettings, PoolCommonParent);
            _counterSceneCharacter = new CounterSceneCharacter();
            ScreenSwitcher.Initialize(ScreenServiceList.screens);
            ScreenSwitcher.ShowScreen(ScreenType.Menu);
        }
    }
}