
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawnSpots;
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;


    private void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
    }


    private void Update()
    {
        if (timeBtwSpawns<= 0){
            int randPos = Random.Range(0, spawnSpots.Length);
            Instantiate(enemy, spawnSpots[randPos].position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;

         }
        else {

            timeBtwSpawns -= Time.deltaTime;
        
        }

    }

}
