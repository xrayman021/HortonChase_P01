using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBeDeadly : MonoBehaviour
{
    public float damageDistance;
    public GameObject thePlayer;
    public int damage = 5;
    private Player playerScript;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = GameObject.Find("Tank");
        playerScript = thePlayer.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, thePlayer.transform.position) < damageDistance)
        {
            playerScript.DecreaseHealth(1);
            Destroy(this.gameObject);
        }
    }
}
