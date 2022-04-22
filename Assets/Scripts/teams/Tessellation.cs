using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tessellation : Team
{
    public override Color teamColor { get { return new Color(255,0,0); } }
    public override string teamName { get { return "Tessellation"; } }
}
