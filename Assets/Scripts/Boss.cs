using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public static int health = 50;
    public Text displayHealth;
    [SerializeField] AudioClip _bossDeathSound = null;
    [SerializeField] ParticleSystem _deathParticles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        displayHealth.text = ""+health;
        if(health <= 0)
        {
            AudioHelper.PlayClip2D(_bossDeathSound, 1f);
            _deathParticles = Instantiate(_deathParticles, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

    }


    
}
