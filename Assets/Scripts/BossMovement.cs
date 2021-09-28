using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public BossBrain theBoss;
    public bool smartMode = true;
    private float smartModeTimer = 0;
    private float shootTimer = 0;
    private float aimTimer = 0;
    public float bossRangex = 44;
    public float bossRangez = 33;
    public float alternatingTime = 2;
    public float shootGap = 1;
    public GameObject player;
    public float aimGap = 0.5f;
    private float modeTimer = 0;
    public float modeGap = 5;
    [SerializeField] ParticleSystem _chargeParticles;
    //[SerializeField] AudioClip _chargeSound = null;
    //bool isCharging = false;

    // Start is called before the first frame update
    void Start()
    {
        //isCharging = false;
        theBoss.destination = new Vector3(Random.Range(-bossRangex, bossRangex), transform.position.y, Random.Range(-bossRangez, bossRangez));
    }

    

    // Update is called once per frame
    void Update()
    {
        modeTimer += Time.deltaTime;
        if(modeTimer > modeGap)
        {
            if(smartMode)
            {
                smartMode = false;
                
            }
            else
            {
                smartMode = true;
            }
            modeTimer = 0;
        }
        if (smartMode)
        {
            smartModeTimer += Time.deltaTime;
            shootTimer += Time.deltaTime;
            if(smartModeTimer > alternatingTime)
            {
                theBoss.destination = new Vector3(Random.Range(-bossRangex, bossRangex), transform.position.y, Random.Range(-bossRangez, bossRangez));
                smartModeTimer = 0;
            }
            if(shootTimer > shootGap)
            {
                transform.LookAt(player.transform.position);
                theBoss.Shoot();
                theBoss.stop = true;
                shootTimer = 0;
            }
            if(theBoss.stop)
            {
                aimTimer += Time.deltaTime;
                if(aimTimer > aimGap)
                {
                    aimTimer = 0;
                    theBoss.stop = false;
                }
            }
        }
        else
        {
            shootTimer += Time.deltaTime;
            if(shootTimer > shootGap)
            {
                theBoss.Shoot();
                shootTimer = 0;

            }
            theBoss.destination = player.transform.position;
            _chargeParticles = Instantiate(_chargeParticles, transform.position, Quaternion.identity);
            /*if (!isCharging)
            {
                AudioHelper.PlayClip2D(_chargeSound, 1f);
                isCharging = true;
            }*/

        }
    }
    
}
