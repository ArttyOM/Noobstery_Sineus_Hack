using Code.DebugTools.Logger;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.HUD.SelectableBlocks
{
    public class UIBlockClickHandler : MonoBehaviour
    {
        private Camera _camera;
        private GameObject _selectedObject;
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
            if (!gameObject.TryGetComponent<BlockViewSettings>(out var blockSettings)) return;
            $"12312312312312312321".Colored(Color.cyan).Log();
            //_selectedObject = Instantiate(blockSettings.SpawnTypeBlock);
            isMouseDown = true;
        }
    }
}