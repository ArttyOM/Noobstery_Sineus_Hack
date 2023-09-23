using UnityEngine;
using UnityEngine.UI;

namespace Code.Block
{
    [DisallowMultipleComponent]
    public class BlockSettings : MonoBehaviour
    {
        public BlockType Type { get; private set; }
        public int Health { get; private set; }
        public int Price { get; private set; }
        //

        public void SetType(BlockType type)
        {
            Type = type;
        }
        public void SetImage(Sprite spriteRenderer)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteRenderer;
        }
        
        public void SetHealth(int health)
        {
            Health = health;
        }

        public void SetPrice(int price)
        {
            Price = price;
        }

        public void ChangeHealth(int GetDamage)
        {
            Health -= GetDamage;
            if (Health <= 0)
            {
                BlockSpawner.ReturnToPool(this);
            }
        }
    }
}