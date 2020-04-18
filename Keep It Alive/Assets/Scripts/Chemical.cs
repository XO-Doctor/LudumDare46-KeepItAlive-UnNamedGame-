using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Chemical", menuName = "Chemical", order = 1)]
public class Chemical : Item
{
    public bool Solid;
    public float PH;
    public Color InfluenceColor;
}
