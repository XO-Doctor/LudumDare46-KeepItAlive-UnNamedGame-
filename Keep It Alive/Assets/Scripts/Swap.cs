using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swap : MonoBehaviour
{
    public Color col;
    public bool solid;
    public GameObject item;
    public string itemname;
    public string itemType;
    public string desription;
    public int amount;
    public bool holding;
    public Sprite icon;
    public bool stackable;
    public Sprite liquidSPR;

    public bool inst;
    public GameObject slotformoving;

    public void grabslot(GameObject vitem, string vitemname, string vdesription, int vamount, Sprite vicon, bool vstackable, Color vcolour, bool vsolid, Sprite vliquidSPR)
    {
        solid = vsolid;
        col = vcolour;
        item = vitem;
        itemname = vitemname;
        desription = vdesription;
        amount = vamount;
        holding = true;
        icon = vicon;
        stackable = vstackable;
        liquidSPR = vliquidSPR;
    }

    private void Update()
    {
        if (holding)
        {
            slotformoving.SetActive(true);
            slotformoving.transform.position = Input.mousePosition;
            slotformoving.GetComponent<Image>().sprite = icon;
            if (!solid)
            {
                if (!inst)
                {
                    GameObject sloticonGO = Instantiate(slotformoving, slotformoving.transform);
                    sloticonGO.transform.position = slotformoving.transform.position;
                    sloticonGO.GetComponent<Image>().enabled = true;
                    sloticonGO.GetComponent<Image>().sprite = liquidSPR;
                    sloticonGO.GetComponent<Image>().color = col;
                    inst = true;
                }
            }
        }
        else
        {
            if(slotformoving.transform.childCount != 0)
            {
                Destroy(slotformoving.transform.GetChild(0).gameObject);
            }
            inst = false;
            slotformoving.SetActive(false);
        }
    }

}