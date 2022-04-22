using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//more of a concept class than anything right now
public abstract class Team //all about team general information, teams inheirt from this class
{
    public abstract Color teamColor { get; }
    public abstract string teamName { get; }
    Player[] players { get; set; }
}
