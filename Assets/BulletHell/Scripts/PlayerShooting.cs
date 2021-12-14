using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : Shooting
{
    void Update()
    {
        if (Input.GetMouseButton(0) && GetShootTime() <= 0)
        {
            Shoot("Player", "Enemy");
        }
    }
}
