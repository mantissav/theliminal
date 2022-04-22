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
        tmp_ref.GetComponent<Rigidbody>().velocity = (-tmp_ref.transform.forward + new Vector3(Random.RandomRange(0,0.01f), 
            Random.RandomRange(0, 0.01f), Random.RandomRange(0, 0.01f))) * muzzleVelocity; //bullets are defined to have a rigidbody at least, and not sure why it is backwords transform
        currentMag -= 1;
    }

    public override void Drop() //didn't enable dropping yet so this is here so C# is quiet
    {
        throw new System.NotImplementedException();
    }
}
