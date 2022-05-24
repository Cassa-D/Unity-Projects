using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;

    public Color hitColor;
    
    public int damage = 1;

    [HideInInspector] public string fatherTag;
    [HideInInspector] public string enemyTag;

    public float bulletForce;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Bullet") && !collision.gameObject.CompareTag(fatherTag))
        {
            hitEffect.GetComponent<SpriteRenderer>().color = hitColor;
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            Destroy(gameObject);

            if (collision.gameObject.CompareTag(enemyTag)) {
                collision.gameObject.GetComponent<Health>().ReceiveDamage(damage);
            }
        }
    }
}
