using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorSpawner : MonoBehaviour
{
    public Transform TractorBossSpawnPoint;
    int times = 0;
    public GameObject TractorBossPreFab;


    void Spawn()
    {
        Instantiate(TractorBossPreFab, TractorBossSpawnPoint.position, TractorBossSpawnPoint.rotation);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            times++;
            if (times == 1)
            {
                Spawn();
            }
        }
    }
}
