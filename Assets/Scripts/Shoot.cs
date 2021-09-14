using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float power;

    public Transform launchpoint;

    public GameObject bullet;

    public GameObject particleSystem;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject currentBullet = Instantiate(bullet, launchpoint.position, launchpoint.rotation);
            currentBullet.GetComponent<Rigidbody>().AddForce(launchpoint.forward);
            GameObject muzzleFlash = Instantiate(particleSystem, launchpoint.position, launchpoint.rotation);
        }
    }
}
