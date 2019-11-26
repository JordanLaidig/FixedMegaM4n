using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSeekerSpawner : MonoBehaviour
{
    public Transform DragonSeekerSpawnPoint;

    public GameObject DragonSeekerPreFab;

    public float timer = 0;

    void Spawn()
    {
        Instantiate(DragonSeekerPreFab, DragonSeekerSpawnPoint.position, DragonSeekerSpawnPoint.rotation);
    }


    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 8;
            Spawn(); 
        }
    }
}
