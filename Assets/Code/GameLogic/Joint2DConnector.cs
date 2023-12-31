using System;
using System.Collections.Generic;
using Code.DebugTools.Logger;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Code.GameLogic
{
    [RequireComponent(typeof(ObservableCollision2DTrigger))]
    public class Joint2DConnector : MonoBehaviour
    {
        [SerializeField] private HitPoints _hitPoints;
        [SerializeField] private Vector2 joint2DAnchor = new Vector2(0, -0.5f);
        
        private ObservableCollision2DTrigger _observableCollision2d;
        private IDisposable _collision2dSubscription;
        private IDisposable _connectedBodyAliveSubscription;

        private SpringJoint2D _joint2D;
        
        private void Awake()
        {
            _joint2D = GetComponent<SpringJoint2D>();
            
            _observableCollision2d = GetComponent<ObservableCollision2DTrigger>();
            _collision2dSubscription = _observableCollision2d.OnCollisionEnter2DAsObservable().First()
                .Subscribe(SetJoint2D);
        }

        private void OnDestroy()
        {
            _collision2dSubscription?.Dispose();
            _connectedBodyAliveSubscription?.Dispose();
        }
        
        
        private void SetJoint2D(Collision2D collision2D)
        {

            float minimumY = collision2D.contacts[0].point.y;
            foreach (var contact in collision2D.contacts)
            {
                float currentY = contact.point.y;
                //Debug.Log(contact.point);
                if (currentY < minimumY) minimumY = currentY;
            }
            // List<float> xPositionsInLowestPoints = new List<float>();
            // foreach (var contact in collision2D.contacts)
            // {
            //     if (contact.point.y <= minimumY + 0.01f)
            //     {
            //         xPositionsInLowestPoints.Add(contact.point.x);
            //         
            //     }
            // }
            ContactPoint2D oneOflowestContact = default;
            foreach (var contact in collision2D.contacts)
            {
                if (contact.point.y <= minimumY + 0.01f)
                {
                    oneOflowestContact = contact;
                    break;
                }
            }

            _joint2D.connectedBody = oneOflowestContact.rigidbody;
            _joint2D.enabled = true;
            oneOflowestContact.point.Colored(Color.gray).Log();
            _joint2D.anchor = joint2DAnchor;
            //_joint2D.connectedAnchor =  new Vector2(-2f, -2f);
            _connectedBodyAliveSubscription = _hitPoints.ObservableDeadStatus
                .Where(x => x == HitPoints.DamagedStatus.DEAD)
                .Subscribe(_=>ReinitJoint2d());
        }

        private void ReinitJoint2d()
        {
            _collision2dSubscription = _observableCollision2d.OnCollisionEnter2DAsObservable().First()
                .Subscribe(SetJoint2D);
        }


    }
}
