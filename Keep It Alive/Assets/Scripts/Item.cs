using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new item", menuName = "item")]
public class Item : ScriptableObject
{
    public GameObject thisitem;
    public string itemName;
    public string description;
    public Sprite icon;
    public bool stackable;
}