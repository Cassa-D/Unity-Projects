using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public int damage = 1;

    public string fatherTag;
    public string enemyTag;

    public float bulletForce;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Bullet" && collision.gameObject.tag != fatherTag) {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            Destroy(gameObject);

            if (collision.gameObject.tag == enemyTag) {
                collision.gameObject.GetComponent<Health>().ReceiveDamage(damage);
            }
        }
    }
}
