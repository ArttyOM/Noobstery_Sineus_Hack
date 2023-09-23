using Code.Block;
using Code.DebugTools.Logger;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.HUD.SelectableBlocks
{
    public class UIBlockClickHandler : MonoBehaviour, IDragHandler, IBeginDragHandler
    {
        private Camera _camera;
        private BlockSettings _selectedObject;
        private bool isMouseDown;

        private void Start()
        {
            _camera = Camera.main;
        }
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            SelectedBlock();
        }
        
        public void OnDrag(PointerEventData eventData)
        {
            if (isMouseDown)
            {
                if(!_selectedObject) return;
                var mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;
                _selectedObject.transform.position = mousePosition;
            }
        }
        
        private void SelectedBlock()
        {
            if (!gameObject.TryGetComponent<BlockUISettings>(out var blockSettings)) return;
            _selectedObject = BlockSpawner.GetBlock(blockSettings.SpawnTypeBlock, blockSettings.transform.position);
            isMouseDown = true;
        }
    }
}