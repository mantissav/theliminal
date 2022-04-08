using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicArmor : Armor
{
    public override void Damage(Bullet bullet, float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
            Destroy(gameObject);
    }
}
