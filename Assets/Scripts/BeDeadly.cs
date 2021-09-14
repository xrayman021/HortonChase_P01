using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeDeadly : MonoBehaviour
{
    public float damageDistance;
    public GameObject theBoss;
    public int damage = 5;
    // Start is called before the first frame update
    void Start()
    {
        theBoss = GameObject.Find("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(this.transform.position, theBoss.transform.position) < damageDistance)
        {
            Boss.health -= damage;
            Destroy(this.gameObject);
        }
    }
}
