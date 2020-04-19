using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    
    public string Name;
    public string Description;
    public Sprite Icon;
    public bool Stackable;

    public bool PickedUp;

    public virtual bool AddToMixture(Chemical Chemical)
    {
        return false;
    }

    public virtual void OnPickup()
    {
        //only here to be overwritten
    }
}