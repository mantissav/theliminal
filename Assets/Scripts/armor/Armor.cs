using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class won't be doing anything crazy, but it makes things such much easier
public abstract class Armor : MonoBehaviour //all armor pieces (even on vehicles) should inhiert this class
{
    public float maxHealth; //all armor should have health and maxHealth of course
    public Team team; //the team this armor belongs to

    //internal stuff
    protected float health;
    //Start handles anything that can't be set in the editor, this is the 'base' start
    void Start()
    {
        health = maxHealth; //all override functions should handle this as well
    }
    //armor pieces shouldn't use any 'Update's since there might be a lot of them
    //formal way of damaging any piece of armor; this should not be circumvented
    public abstract void Damage(Bullet bullet, float damageAmount);
}
