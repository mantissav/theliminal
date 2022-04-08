using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//the key thing about explosive bullets is that they have triggers which act as the Radius of the blast
public abstract class ExplosiveBullet : Bullet
{
    public Collider selectedTrigger;
    //used to init anything that can't be set in the editor or otherwise
    void Start() { //in this instance, we want to get the size of the trigger
        Collider[] colliders = GetComponents<Collider>();
        //we'll define the first trigger collider as the selected radius for this explosive
        foreach (Collider collider in colliders)
            if (collider.isTrigger) {
                selectedTrigger = collider;
                break;
            }
    }
    //update isn't used at all with any type of bullet since callbacks are much quicker and more logical
    abstract public void OnSurfaceRadius(GameObject surface);
    //called whenever the bullet is in the radius of a piece of armor that is not on a vehicle 
    abstract public void OnArmorRadius(Armor armor);
    //called whenever the bullet is in radius distance from a piece of armor that is on a vehicle 
    abstract public void OnArmorVehicleRadius(Vehicle vehicle, Armor armor);
    //called whenever a player is in the radius of the bullet 
    abstract public void OnPlayerRadius(Player player);
    //called for every object in radius; general function if behavior doesn't depend on type of object hit
    abstract public void Radius(GameObject objectRadius);
    //note that this function is overriden here and if it is going to be used it has to impement the same functionality
    public override void Hit(GameObject objectHit) //called after the bullet hits something but after all 'hit' callbacks
    {
        Collider[] collidersHit = Physics.OverlapBox(selectedTrigger.bounds.center, selectedTrigger.bounds.size / 2);
        foreach(Collider collider in collidersHit){
            if (collider.tag == "Player")
                if (collider.transform.parent.transform != transform)
                    OnPlayerRadius(collider.GetComponent<Player>());
                else
                    return;
            else
            {
                if (collider.tag == "Armor")
                    if (collider.transform.parent && collider.transform.parent.tag == "Armor")
                        OnArmorVehicleRadius(collider.transform.parent.GetComponent<Vehicle>(), collider.GetComponent<Armor>());
                    else
                        OnArmorRadius(collider.GetComponent<Armor>());
                else
                    OnSurfaceRadius(collider.gameObject);
            }
            Radius(collider.gameObject);
        }
    }
}
