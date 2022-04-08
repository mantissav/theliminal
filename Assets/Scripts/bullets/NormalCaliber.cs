using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCaliber : Bullet
{
    public override void OnArmorHit(Armor armor) {
        Debug.Log("Hit armor");
        armor.Damage(this, directDamage);
    }
    public override void OnArmorVehicleHit(Vehicle vehicle, Armor armor) {
        Debug.Log("Hit vehicle armor");
    }
    public override void OnPassBy(Player player) { }
    public override void OnPlayerHit(Player player) {
        player.walkAcceleration = 0; //test for now
        Debug.Log("Hit player");
    }
    public override void OnSurfaceHit(GameObject surface) { }
}
