using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples.Strategy
{
    public class NoMoveBehavior : IMoveable
    {

        Rigidbody _rb;
        

        public NoMoveBehavior(Rigidbody rb)
        {
            _rb = rb;
            _rb.velocity = Vector3.zero;
        }

        public void Move()
        {
            //None
        }
    }
}

