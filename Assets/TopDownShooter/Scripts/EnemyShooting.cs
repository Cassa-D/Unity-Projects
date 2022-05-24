using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : Shooting
{
    void Update() {
        if (GetShootTime() <= 0)
        {
            Shoot("Enemy", "Player");
        }
    }
}
