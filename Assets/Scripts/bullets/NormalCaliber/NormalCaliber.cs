using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCaliber : Bullet
{
    Rigidbody bulletBody;
    void Start()
    {
        bulletBody = GetComponent<Rigidbody>();
    }
    public override void Hit(GameObject objectHit)
    {
        //Debug.Log("Hit " + objectHit.name); //for testing
    }

    public override void OnArmorHit(Armor armor) {
        if (armor.GetType().Name == "BasicArmor") //only if BasicArmor is hit, example use
            armor.Damage(this, directDamage * bulletBody.velocity.magnitude);
        Debug.Log(directDamage * bulletBody.velocity.magnitude);
    }
    public override void OnArmorVehicleHit(Vehicle vehicle, Armor armor) {
        //Debug.Log("Hit vehicle armor");
    }
    public override void OnPassBy(Player player) { }
    public override void OnPlayerHit(Player player) {
        player.walkAcceleration = 0; //test for now
       // Debug.Log("Hit player");
    }
    public override void OnSurfaceHit(GameObject surface) { }
}
