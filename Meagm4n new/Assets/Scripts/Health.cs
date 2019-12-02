using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public CameraController cam;
    public int health;
    public int maxHealth = 100;

    private void Start()
    {
        health = maxHealth;
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }
    public int getHealth()
    {
        return health;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            cam.targets.Remove(transform);
            cam.movable = true;
            Destroy(gameObject);
        }
        else
        {
            if (this.CompareTag("Player"))
            {
                Rigidbody2D rb = this.gameObject.GetComponent<Rigidbody2D>();
                rb.AddForce(-this.gameObject.transform.right * 50);
                rb.AddForce(this.gameObject.transform.up * 50);
                JorgePlayerController jorge = gameObject.GetComponent<JorgePlayerController>();
                CarsonPlayerController carson = gameObject.GetComponent<CarsonPlayerController>();
                JoePlayerController joe = gameObject.GetComponent<JoePlayerController>();
                JohnsonPlayerController johnson = gameObject.GetComponent<JohnsonPlayerController>();
                if (jorge != null)
                    jorge.knockback();
                if (carson != null)
                    carson.knockback();
                if (joe != null)
                    joe.knockback();
                if (johnson != null)
                    johnson.knockback();
            }
            //if anyone knows how to make the sprite flash, go ahead and put it here....
        }
    }
    public void Heal(int hp)
    {
        health += hp;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

}
