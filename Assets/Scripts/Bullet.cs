using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour //all other bullets should inheirt from this class
{
    public float passByRange;
    public float directDamage; //here for convience, but this must be applied directly by derived classes
    // Start is the time to init any things you can't do in the editor
    void Start()
    {
        
    }
    //bullets shouldn't do anything in any 'Updates' since that would be a large performance problem thing

    //called whenever this bullet passes by a player within 'passByRange' units
    abstract public void OnPassBy(Player player); //(all 'Player's test for this btw)
    //called whenever the bullet hits something on the map; not armor and not a player
    abstract public void OnSurfaceHit(GameObject surface);
    //called whenever the bullet hits a piece of armor that is not on a vehicle 
    abstract public void OnArmorHit(Armor armor);
    //called whenever the bullet hits a piece of armor that is on a vehicle 
    abstract public void OnArmorVehicleHit(Vehicle vehicle, Armor armor);
    //called whenever the bullet hits a player 
    abstract public void OnPlayerHit(Player player);

    //this handles the calling of the hit functions, makes life so much easier
    private void OnCollisionEnter(Collision collision) //should never be overriden
    {
        if (collision.collider.tag == "Player")
            if (collision.collider.transform.parent.transform != transform)
                OnPlayerHit(collision.collider.GetComponent<Player>());
            else
                return;
        else
        {
            if (collision.collider.tag == "Armor")
                if (collision.collider.transform.parent && collision.collider.transform.parent.tag == "Armor")
                    OnArmorVehicleHit(collision.collider.transform.parent.GetComponent<Vehicle>(), collision.collider.GetComponent<Armor>());
               else
                    OnArmorHit(collision.collider.GetComponent<Armor>());
            /*else
                OnSurfaceHit(collision.collider.gameObject);*/
        }
        Debug.Log("Hit " + collision.collider.gameObject.name); //for testing
        //afterwards the bullet should be removed
        Destroy(gameObject);
    }

}
