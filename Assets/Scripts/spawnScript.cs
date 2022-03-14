using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour
{
    //game object arrays for the spawn points and targets so they can be chosen at random
    public GameObject[] spawnPoints, targets;
    public float spawnRate;
    public int maxSpawns;
    private int spawnCount;
  
    void Start()
    {
        //calling spawn function and repeating the spawn function
        Spawn();
        InvokeRepeating("Spawn", spawnRate, spawnRate);
    }


    void Spawn()
    {
        if (spawnCount < maxSpawns)
        {
            //adding targets from array at random, from spawnpoint array
            maxSpawns++;
            int randomTarget = Random.Range(0, targets.Length);
            int randomSpawn = Random.Range(0, spawnPoints.Length);
            Instantiate(targets[randomTarget], spawnPoints[randomSpawn].transform.position, spawnPoints[randomSpawn].transform.rotation);
        }
    }
}
