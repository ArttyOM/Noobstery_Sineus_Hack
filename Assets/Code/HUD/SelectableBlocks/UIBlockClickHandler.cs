using System;
using Code.Block;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.HUD.SelectableBlocks
{
    public class UIBlockClickHandler : MonoBehaviour, IDragHandler, IBeginDragHandler
    {
        [SerializeField]
        private PriceBlock _priceBlock;

        private Camera _camera;
        private BlockSettings _selectedObject;
        private Collider2D _selectCollider;
        private Rigidbody2D _selectRigidBody;
        private bool isMouseDown;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0) && isMouseDown)
            {
                isMouseDown = false;
                _selectedObject = null;
                _selectCollider.enabled = true;
                _selectRigidBody.isKinematic = false;
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            SelectedBlock();
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (isMouseDown)
            {
                if (!_selectedObject) return;
                var mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0;
                _selectedObject.transform.position = mousePosition;
            }
        }

        private void SelectedBlock()
        {
            if (!gameObject.TryGetComponent<BlockUISettings>(out var blockSettings)) return;
            if (blockSettings.BlockConfig.PriceBlock > _priceBlock._currentResources) return;
            
            _priceBlock.DecreaseResources(blockSettings.BlockConfig.PriceBlock);

            _selectedObject = BlockSpawner.GetBlock(blockSettings.BlockConfig.SpawnTypeBlock,
                blockSettings.transform.position);
            _selectCollider = _selectedObject.GetComponent<Collider2D>();
            _selectRigidBody = _selectedObject.GetComponent<Rigidbody2D>();
            _selectCollider.enabled = false;
            _selectRigidBody.isKinematic = true;
            isMouseDown = true;
        }
    }
}