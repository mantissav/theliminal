using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Decorator : MonoBehaviour //decoraters from other levels should inheirt this class
{
    //imporant things that should be modified in the editor
    public GameObject[] gameobjects; //objects that may be placed
    public float[] chances; //out of 1; i.e 0.1 = 10% chance of placement

    //TODO: Add the capablitiy for specific conditions required for an object to spawn; i.e it needs to be hot for lava to run or something

    //we will use this class to represent relations between models and their spawn chance, likelyhood, etc
    struct DecoratedObject
    {
        GameObject gameobject;
        float chance;
        public DecoratedObject(GameObject gameobject, float chance) //this is terrible
        {
            this.gameobject = gameobject;
            this.chance = chance; 
        }
    }
    DecoratedObject[] objects; //this just makes things easier
    // Start is used for any init before this class is used by the exterior or interior generators
    void Start()
    {
        objects = new DecoratedObject[gameobjects.Length];
        for (int i = 0; i < objects.Length; i++)
            objects[i] = new DecoratedObject(gameobjects[i], chances[i]); //i feel really bad about this
    }
    //this function gets called by the generator (which can be interior or exterior) after main generating has been completed
    abstract public void Decorate(Terrain activeTerrain); //this will be for exterior things 
    abstract public void Decorate(); //interior things

}
