using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FowDecorator : Decorator
{

    public override void Decorate(Terrain activeTerrain) //decorate exterior gen only
    {
        Debug.Log("big W");
    }
    public override void Decorate() { } //wont have any interior generation here

}
