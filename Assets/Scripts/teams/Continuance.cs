using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Continuance : Team
{
    public override Color teamColor { get { return new Color(0, 0, 255); } }
    public override string teamName { get { return "Continuance"; } }
}
