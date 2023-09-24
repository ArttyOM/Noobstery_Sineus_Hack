using System;
using TMPro;
using UnityEngine;

namespace Code.HUD.SelectableBlocks
{
    public class PriceBlock : MonoBehaviour
    {
        [field: SerializeField] public PriceSettings PriceSettings { get; private set; }

        [SerializeField] public float TimeForIncreaseResources;
        [SerializeField] public int CountIncreaseResources;
        private float _currentTimer;
        private int _startResources;
        public int _currentResources { get; private set; }
        private TextMeshProUGUI _resourcesText;

        private void Awake()
        {
            _currentTimer = TimeForIncreaseResources;
            _startResources = PriceSettings.StartResources;
            _resourcesText = PriceSettings.ResourcesText;
            _resourcesText.text = _startResources.ToString();
            _currentResources = _startResources;
        }

        private void Update()
        {
            _currentTimer -= Time.deltaTime;

            if (_currentTimer <= 0f)
            {
                _currentTimer = TimeForIncreaseResources;

                IncreaseResources(CountIncreaseResources);
            }
        }

        private void IncreaseResources(int increaseResources)
        {
            _currentResources += increaseResources;
            _resourcesText.text = _currentResources.ToString();
        }

        public void DecreaseResources(int decreaseResources)
        {
            _currentResources -= decreaseResources;
            if (_currentResources <= 0)
            {
                _currentResources = 0;
            }
            
            _resourcesText.text = _currentResources.ToString();
        }
    }
}