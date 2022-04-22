using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this class is for consumables like potions
//IMPORTANT: this class uses the 'Start' method so if you need to use this be sure to implement the base functionality
public abstract class Consumable : Item
{
    protected uint maxAmount, currentAmount;
    void Start()
    {
        currentAmount = maxAmount;
    }
}
