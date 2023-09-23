using System;
using System.Collections.Generic;
using Code.Block;
using Code.Characters;
using Code.HUD;
using Code.HUD.CharacterCounter;
using Code.Pools;
using TMPro;
using UnityEngine;

namespace Code.Main
{
    [DisallowMultipleComponent]
    public class EntryPoint : MonoBehaviour
    {
        [field: SerializeField] public BlockSpawnerSettings BlockSpawnerSettings { get; private set; }
        [field: SerializeField] public ScreenService ScreenServiceList { get; private set; }
        [field: SerializeField] public PoolCommonParent PoolCommonParent { get; private set; }
        [field: SerializeField] public TextMeshProUGUI TextMeshProUGUI { get; private set; }
        private CounterSceneCharacter _counterSceneCharacter;
        

        private void Awake()
        {
            Time.timeScale = 0;
            BlockSpawner.Initialize(BlockSpawnerSettings, PoolCommonParent);
            _counterSceneCharacter = new CounterSceneCharacter(TextMeshProUGUI);
            ScreenSwitcher.Initialize(ScreenServiceList.screens);
            ScreenSwitcher.ShowScreen(ScreenType.Menu);
            
        }

        public IObservable<bool> getGameOverEvents()
        {
            return _counterSceneCharacter.CharacterCount.OnGameOver;
        }
    }
}