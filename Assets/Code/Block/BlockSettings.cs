using UnityEngine;
using UnityEngine.UI;

namespace Code.Block
{
    [DisallowMultipleComponent]
    public class BlockSettings : MonoBehaviour
    {
        public BlockType Type { get; private set; }
        public int Health { get; private set; }

        public void SetType(BlockType type)
        {
            Type = type;
        }
        public void SetImage(Sprite spriteRenderer)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteRenderer;
            SetSizeCollider(spriteRenderer);
        }
        
        public void SetHealth(int health)
        {
            Health = health;
        }

        private void SetSizeCollider(Sprite spriteRenderer)
        {
            gameObject.GetComponent<BoxCollider2D>().size = spriteRenderer.bounds.size;
        }
    }
}