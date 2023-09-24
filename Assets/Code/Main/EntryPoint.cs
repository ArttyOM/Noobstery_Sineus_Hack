using System;
using System.Collections.Generic;
using Code.Block;
using Code.Characters;
using Code.HUD;
using Code.HUD.CharacterCounter;
using Code.HUD.SelectableBlocks;
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
        [field: SerializeField] public CharacterCounterView CharacterCounterView { get; private set; }
        [field: SerializeField] public PriceSettings PriceSettings { get; private set; }
        //private PriceBlock _priceBlock;
        private CounterSceneCharacter _counterSceneCharacter;
        

        private void Awake()
        {
            Time.timeScale = 0;
            var characters = FindObjectsOfType<CharacterMarker>();
            //_priceBlock = new PriceBlock(PriceSettings.ResourcesText, PriceSettings.StartResources);
            _counterSceneCharacter = new CounterSceneCharacter(CharacterCounterView.CounterText, characters);
            BlockSpawner.Initialize(BlockSpawnerSettings, PoolCommonParent);
            ScreenSwitcher.Initialize(ScreenServiceList.screens);
            ScreenSwitcher.ShowScreen(ScreenType.Menu);
        }
    }
}