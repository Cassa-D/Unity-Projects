using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hp = 10;
    public HealthBar healthBar;

    void Start()
    {
        healthBar.SetMaxHealth(hp);
    }

    public void ReceiveDamage(int damage)
    {
        hp -= damage;

        healthBar.SetHealth(hp);

        if (hp <= 0) {
            Destroy(gameObject);
        }
    }
}
