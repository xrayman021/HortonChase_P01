using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTank : MonoBehaviour
{
    public float speed;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = this.gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        if(horizontal < 0)
        {
            transform.Rotate(0, -1, 0);
        }
        if (horizontal > 0)
        {
            transform.Rotate(0, 1, 0);
        }

        if (horizontal == 0 && vertical == 0)
        {
            _rb.velocity = new Vector3(0, 0, 0);
        }

        if (vertical > 0) 
        {
            _rb.AddForce(transform.forward * speed);
        }
        if (vertical < 0)
        {
            _rb.AddForce(-transform.forward * speed);
        }



    }
}
