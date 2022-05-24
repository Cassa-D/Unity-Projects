using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float shootRecoil = 10f;
    float shootTime = 0;

    void Start() {
        shootTime = shootRecoil;
    }

    void FixedUpdate()
    {
        if (shootTime > 0)
        {
            shootTime -= Time.fixedDeltaTime;

            if (shootTime <= 0)
            {
                shootTime = 0;
            }
        }
    }

    public float GetShootTime() {
        return shootTime;
    }

    public void Shoot(string fatherTag, string enemyTag)
    {
        shootTime = shootRecoil;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().fatherTag = fatherTag;
        bullet.GetComponent<Bullet>().enemyTag = enemyTag;

        float bulletForce = bullet.GetComponent<Bullet>().bulletForce;

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
