using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public static int health = 50;
    public Text displayHealth;

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
            Destroy(this.gameObject);
        }

    }


    
}
