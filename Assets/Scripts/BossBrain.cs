using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBrain : MonoBehaviour
{
    public Vector3 destination;
    public float stopDistance;
    public float speed;
    public bool stop = false;
    public GameObject bullet;
    public Transform launchPoint;
    public float shootPower;
    [SerializeField] AudioClip _shootSound = null;
    [SerializeField] ParticleSystem _shootParticles;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Shoot()
    {
        GameObject currentBullet = Instantiate(bullet, launchPoint.position, launchPoint.rotation);
        AudioHelper.PlayClip2D(_shootSound, 1f);
        _shootParticles = Instantiate(_shootParticles, transform.position, Quaternion.identity);
        currentBullet.GetComponent<Rigidbody>().AddForce(launchPoint.forward * shootPower);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, destination) > stopDistance && !stop)
        {
            
            transform.LookAt(destination);
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }
}
