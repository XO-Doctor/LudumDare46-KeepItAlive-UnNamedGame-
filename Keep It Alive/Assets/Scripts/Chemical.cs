using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Effects
{
    Mutate,
    Posion,
    Drunk,
    Happy,
    Calm,
    Anger,
    Dizzy,
    Nutrition,
    Gas,
    Plants,
    Starve,
    Bloat,
    Pain
}

[CreateAssetMenu(fileName = "New Chemical", menuName = "Chemical", order = 1)]
public class Chemical : Item
{
    public bool Solid;
    public float PH;
    public Color InfluenceColor;

    public float BurnTemperature;
    public float FreezeTemperature;

    public Effects Effect;
    public int EffectIntensity;
}
