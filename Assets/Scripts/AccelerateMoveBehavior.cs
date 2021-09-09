using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples.Strategy
{
    public class AccelerateMoveBehavior : IMoveable
    {
        float _currentSpeed;
        Rigidbody _rb = null;
        float _accelerateSpeed;
        Transform _objectTransform = null;

        public AccelerateMoveBehavior(Rigidbody rb, float accelerateSpeed)
        {
            _rb = rb;
            _accelerateSpeed = accelerateSpeed;
            _objectTransform = _rb.transform;
        }

        public void Move()
        {
            _rb.velocity = _objectTransform.forward * _accelerateSpeed;
        }
    }
}
