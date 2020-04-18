using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;








public class Swap : MonoBehaviour
{
    public GameObject item;
    public string itemname;
    public string itemType;
    public string desription;
    public int amount;
    public bool holding;
    public Sprite icon;
    public bool stackable;
    public GameObject selectedUI;

    public void grabslot(GameObject vitem, string vitemname, string vdesription, int vamount, Sprite vicon, bool vstackable)
    {
        item = vitem;
        itemname = vitemname;
        desription = vdesription;
        amount = vamount;
        holding = true;
        icon = vicon;
        stackable = vstackable;
    }

    public void Update()
    {
        if (holding)
        {
            selectedUI.SetActive(true);
            selectedUI.GetComponentInChildren<Image>().sprite = icon;
            selectedUI.GetComponentInChildren<Text>().text = amount.ToString();
            selectedUI.transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        else
        {
            selectedUI.SetActive(false);
        }
    }
}