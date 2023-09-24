using System;
using System.Collections.Generic;
using Code.DebugTools.Logger;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float pitStopTime = 1f;
        
        [SerializeField] private TargetJoint2D target;
        [SerializeField] private GameObject movementPointsParent;

        private Transform[] _points;// = new List<Transform>();
        

        
        private void Awake()
        {
            _points = movementPointsParent.GetComponentsInChildren<Transform>();
            
            _points.Length.Colored(Color.green).Log();
            Observable.Interval(TimeSpan.FromSeconds(pitStopTime))
                .Subscribe(i =>
                {
                    target.target = _points[i % _points.Length].position;
                });
        }
    }
}
