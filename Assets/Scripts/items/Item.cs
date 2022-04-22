using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this class is a general item which can be held and and in the inventory of the player, **cant be on the group**
public abstract class Item : MonoBehaviour
{
    public Player owner; //the player this item is in the inventory of, should never be NULL
    public string displayName;
    public GameObject model; //what is placed in the player's hand when this item is held out
    public Image preview; //shown in inventory

    ///when the player 'drops' the item
    public abstract void Drop();
    //called every frame this item is held in the owner's hand
    public abstract void WhileHeld();

}
