using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnThis;
    public int spawnThisMany;
    public int leftToSpawn;
    public float spawnGap;
    private float timer;
    //public bool spawning;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnGap)
        {
            timer = 0;
            if (leftToSpawn > 0)
            {
                leftToSpawn -= 1;
                Instantiate(spawnThis, this.transform.position, this.transform.rotation);
            }
            else
            {
                GameObject[] objects = GameObject.FindGameObjectsWithTag(spawnThis.tag);
                if (objects.Length == 0)
                {
                    leftToSpawn = spawnThisMany;
                }
            }


        }
    }
}