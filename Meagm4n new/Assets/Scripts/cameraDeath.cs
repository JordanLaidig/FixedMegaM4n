using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraDeath : MonoBehaviour
{
    Health Jorge;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Jorge = collision.GetComponent<Health>();
            if (Jorge != null)
            {
                Jorge.TakeDamage(Jorge.getMaxHealth());
            }
        }
    }
}
