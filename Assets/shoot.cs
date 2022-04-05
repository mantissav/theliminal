using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shoot : MonoBehaviour
{
    //things for script to work
    public Transform barrel;
    public GameObject bullet;
    public Text current_mag_text, total_ammo_current_text; //should be in the 'ui' canvas

    //gun properties
    public uint max_mag, max_ammo;
    public uint firerate; // in rps
    public uint muzzle_velocity; //so that guns could use same ammow with dif penatration and stats since guns play a role in how ammunition behaves as well

    //internal things
    uint current_mag, total_ammo_current;
    // Start is called before the first frame update
    void Start()
    {
        //so there are no weird errors upon spawning
        total_ammo_current = max_ammo - max_mag;
        current_mag = max_mag;
    }

    // Update is called once per frame
    void Update()
    {
        //update the ui
        current_mag_text.text = current_mag.ToString();
        total_ammo_current_text.text = total_ammo_current.ToString();
        //reload
        if (Input.GetKey(KeyCode.R))
        {
            total_ammo_current = total_ammo_current - (max_mag - current_mag);
            current_mag = max_mag;
        }
        //NOTE: Only use mousebuttondown for semi auto, for full auto figure out time thing to shoot at proper firerate
        if (Input.GetMouseButtonDown(0) && current_mag > 0) //if left mouse down, shoot
        {
            GameObject tmp_ref = Instantiate(bullet);
            tmp_ref.transform.position = barrel.transform.position;
            tmp_ref.transform.rotation = barrel.transform.rotation;
            tmp_ref.GetComponent<Rigidbody>().velocity = -tmp_ref.transform.forward * muzzle_velocity; //bullets are defined to have a rigidbody at least, and not sure why it is backwords transform
            current_mag -= 1;
            
        }

    }
}
