using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Gun : MonoBehaviour //all other guns should inheirt from this class
{
    //all guns need these things
    public Transform barrel;
    public GameObject bullet;
    public Player player;
    public Text currentMagText, totalAmmoCurrentText; //should be in the 'ui' canvas

    //base gun properties, other guns should add on to this
    public uint maxMag, maxAmmo;
    public uint firerate; // in rps
    public uint muzzleVelocity; //so that guns could use same ammow with dif penatration and stats since guns play a role in how ammunition behaves as well

    //internal things
    protected uint currentMag, ammoCurrent;
    protected Rigidbody playerBody;
    // Start is called before the first frame update
    void Start()
    {
        //so there are no weird errors upon spawning, if this function is overriden this has to be done
        ammoCurrent = maxAmmo - maxMag;
        currentMag = maxMag;
        //override functions should do this as well
        playerBody = player.GetComponent<Rigidbody>();
    }

    abstract public void Reload(); //called in 'base' Update method, this is just to structure things a bit better
    //movement speed is passed in so it is imposssible to 'catch up' with your own bullets
    abstract public void Fire(); //called in 'base' Update method when mouse is pressed down; not when held

    //any other complex behavior required the overriding of Update

    //do 'shoot checking' in Update so players don't expierience any delay when reloading or shooting

    //'base' update method that calls the other abstract functions, this just makes things a bit easier for quick guns
    void Update()
    {
        //update the ui
        currentMagText.text = currentMag.ToString();
        totalAmmoCurrentText.text = ammoCurrent.ToString();
        //reload
        if (Input.GetKey(KeyCode.R))
        {
            //base Update handles this since this should be the same for all reloads
            ammoCurrent = ammoCurrent - (maxMag - currentMag);
            currentMag = maxMag;
            Reload();
        }
        //NOTE: Only use mousebuttondown for semi auto, for full auto figure out time thing to shoot at proper firerate
        if (Input.GetMouseButtonDown(0) && currentMag > 0) //if left mouse down, shoot
        {
            Fire();
        }

    }
}
