using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new item", menuName = "item")]
public class Item : ScriptableObject
{
    
    public string Name;
    public string Description;
    public Sprite Icon;
    public bool Stackable;
}