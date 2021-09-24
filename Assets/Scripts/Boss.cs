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
    [SerializeField] int _damageAmount = 1;
    [SerializeField] ParticleSystem _impactParticles;
    [SerializeField] AudioClip _impactSound;

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
            gameObject.SetActive(false);
            AudioHelper.PlayClip2D(_bossDeathSound, 1f);
            _deathParticles = Instantiate(_deathParticles, transform.position, Quaternion.identity);
            //Destroy(this.gameObject);
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            PlayerImpact(player);
            ImpactFeedback();
            //CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
        }
    }

    protected virtual void PlayerImpact(Player player)
    {
        player.DecreaseHealth(_damageAmount);
    }

    private void ImpactFeedback()
    {
        //particles
        if (_impactParticles != null)
        {
            _impactParticles = Instantiate(_impactParticles, transform.position, Quaternion.identity);
        }
        //audio TODO - consider object pooling for performance
        if (_impactSound != null)
        {
            AudioHelper.PlayClip2D(_impactSound, 1f);
        }
    }



}
