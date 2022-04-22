using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleObject : Object
{
    public Rifle rifle;
    public override void Despawn()
    {
        Destroy(gameObject);
    }

    public override void PickUp(Player player, int slot)
    {
        player.quickSlots[slot] = rifle;
        Destroy(gameObject);
    }
}
