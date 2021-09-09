using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples.Strategy
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class Projectile : MonoBehaviour
    {
        IMoveable _moveBehavior;

        [SerializeField] float _travelSpeed = 10;
        public float TravelSpeed => _travelSpeed;

        Rigidbody _rb = null;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();

            _moveBehavior = new LinearMoveBehavior(_rb, _travelspeed);
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Projectile collision");
        }

        private void FixedUpdate()
        {
            _moveBehavior.Move();
        }

        public void SetMoveBehavior(IMoveable newMoveBehavior)
        {
            Debug.Log("Changing projectile flight behavior!");
            _moveBehavior = newMoveBehavior;
        }
    }
}
