using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Gun
{
    public override void Reload() { } //we don't do anything special here like sounds or animations yet

    public override void Fire()
    {
        GameObject tmp_ref = Instantiate(bullet);
        tmp_ref.transform.position = barrel.transform.position;
        tmp_ref.transform.rotation = barrel.transform.rotation;
        tmp_ref.GetComponent<Rigidbody>().velocity = -tmp_ref.transform.forward * muzzleVelocity; //bullets are defined to have a rigidbody at least, and not sure why it is backwords transform
        currentMag -= 1;
    }
}
