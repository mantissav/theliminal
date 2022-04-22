using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is basically like Item but for things physically on the ground
//doesn't necessarly have to become an Item and doesn't have to be pick-up-able
public abstract class Object : MonoBehaviour
{
    public string displayName = "X", toolTip = "This is not for you."; //omnious text to conver up any bugs
    public GameObject model; //model shown on the ground
    public float despawnTime;
    void Start() //shouldn't really be overriden 
    {
        Invoke("Despawn", despawnTime);
    }
    //called when 'player' interacts with this object on the ground, or 'picks' it.
    public abstract void PickUp(Player player, int slot);
    //what happens when 'despawnTime' is up
    public abstract void Despawn();
}
