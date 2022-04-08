using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//an implement is basically just a piece of equipment that can be constructed and *used*. Like a turret or something
public abstract class Implement : MonoBehaviour //all other implements should inheirt this class
{
    public Player activePlayer; //player who is currently using this implementation
    public Transform activeLocation; //the required location for a player who is interacting with this implement
    protected bool interaction; //if being interacted with currently
    //start is called upon this implement's placement; provided by monobehavior, use it well
    void Start() { }
    //when the player first interacts with this implement
    public abstract void OnEnterInteraction(Player player);
    //called every other frame after OnEnterInteraction
    public abstract void OnContinueInteraction(Player player);
    //(all other functionally should be able to be done in those functions)

    //all functions below should not be overriden unless absolutly required
    public void Interact(Player player)
    {
        OnEnterInteraction(activePlayer = player); //set activePlayer to player and run callback
        interaction = true;
    }
    public void StopInteract(Player player)
    {
        if(player == activePlayer) //just to prevent any weird bugs
            interaction = false;
    }
    private void Update() //provided by monobehavior, useful for running the OnContinueInteraction callback
    {
        if (interaction)
            OnContinueInteraction(activePlayer);
    }
}
