﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    
    public string Name;
    public string Description;
    public Sprite Icon;
    public bool Stackable;

    public virtual bool AddToMixture(Chemical Chemical)
    {
        return false;
    }
}