using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples.Strategy
{
    public class LinearMoveBehavior : IMoveable
    {
        float _travelSpeed;
        Rigidbody _rb = null;
        Transform _objectTransform = null;

        public LinearMoveBehavior(Rigidbody rb, float travelSpeed)
        {
            _rb = rb;
            _travelSpeed = travelSpeed;
            _objectTransform = _rb.transform;
        }

        public void Move()
        {
            _rb.velocity = _objectTransform.forward * _travelSpeed;
        }
    }
}
