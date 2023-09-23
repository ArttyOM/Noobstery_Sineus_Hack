using System;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Code.GameLogic
{
    [RequireComponent(typeof(ObservableCollision2DTrigger))]
    public class Joint2DConnector : MonoBehaviour
    {
        private ObservableCollision2DTrigger _observableCollision2d;
        private IDisposable _collision2dSubscription;

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
            _joint2D.anchor = oneOflowestContact.point;

            ActivateDamageReceiver();
        }

        /// <summary>
        /// Блоки не должны получать урон от начального падения.
        /// Поэтому получение урона включаем только после настройки джоинтов
        /// </summary>
        private void ActivateDamageReceiver()
        {
            this.GetComponent<DamageReceiver>().Activate();
        }
    }
}
