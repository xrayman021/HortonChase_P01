using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class BossBeDeadly : MonoBehaviour
{
    public float damageDistance;
    public GameObject thePlayer;
    public int damage = 5;
    private Player playerScript;
    [SerializeField] AudioClip _playerDamagedSound = null;
    
    //private Shake shake;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = GameObject.Find("Tank");
        playerScript = thePlayer.GetComponent<Player>();
        //shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, thePlayer.transform.position) < damageDistance)
        {
            AudioHelper.PlayClip2D(_playerDamagedSound, 1f);
            CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
            //shake.CamShake();
            playerScript.DecreaseHealth(1);
            Destroy(this.gameObject);
        }
    }
}
