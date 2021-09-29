using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float power;

    public Transform launchpoint;

    public GameObject bullet;

    public GameObject particleSystem;

    [SerializeField] AudioClip _shootSound = null;

    public float fireRate = 0.5F;

    private float nextFire = 0.0F;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject currentBullet = Instantiate(bullet, launchpoint.position, launchpoint.rotation);
            AudioHelper.PlayClip2D(_shootSound, 1f);
            currentBullet.GetComponent<Rigidbody>().AddForce(launchpoint.forward * power);
            GameObject muzzleFlash = Instantiate(particleSystem, launchpoint.position, launchpoint.rotation);
        }
    }
}
