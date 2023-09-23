using System;
using UniRx.Triggers;
using UnityEngine;

namespace Code.GameLogic
{
    [RequireComponent(typeof(ObservableCollision2DTrigger))]
    public class DamageableMarker : MonoBehaviour
    {
        private ObservableCollision2DTrigger _collisionObservable;
        
        public IObservable<Collision2D> GetCollision2DEnterAsObservable()
        {
            return _collisionObservable.OnCollisionEnter2DAsObservable();
        }
    
        private void Awake()
        {
            _collisionObservable = GetComponent<ObservableCollision2DTrigger>();
        }

    }
}
