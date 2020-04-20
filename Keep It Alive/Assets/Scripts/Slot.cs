using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject item;
    public string Itemname;
    public string type;
    public string description;
    public int amount;
    public bool empty;
    public Swap swap;
    public Color col;
    public bool solid;
    public Sprite liquidSP;
    public Sprite liquidCube;
    public GameObject liquid;
    public bool nosolid;

    public Transform sloticonGO;
    public Sprite icon;
    public bool stackable;

    public bool mixernaterTop;

    private void Start()
    {
        Button button = this.GetComponent<Button>();
        sloticonGO = transform.GetChild(0);
        sloticonGO.GetComponent<Image>().enabled = false;
    }

    public void clearSlot()
    {
        item = null;
        Itemname = null;
        type = null;
        description = null;
        amount = 0;
        empty = true;
        icon = null;
        sloticonGO.GetComponent<Image>().enabled = false;
        if(sloticonGO.childCount != 0)
        {
            Destroy(sloticonGO.GetChild(0).gameObject);
        }
    }

    public void select()
    {
        if (!empty)
        {
            if (!swap.holding)
            {
                swap.grabslot(item, Itemname, description, amount, icon, stackable, col, solid, liquidSP);
                empty = true;
                clearSlot();
            }
            else
            {
                if (stackable)
                {
                    if (Itemname == swap.itemname)
                    {
                        swap.holding = false;
                        amount = amount + swap.amount;
                        UpdateSlot();
                    }
                }
            }
        }
        else
        {
            if (swap.holding)
            {
                if (!mixernaterTop)
                {
                    item = swap.item;
                    liquidSP = swap.liquidSPR;
                    col = swap.col;
                    solid = swap.solid;
                    Itemname = swap.itemname;
                    type = swap.itemType;
                    description = swap.desription;
                    icon = swap.icon;
                    stackable = swap.stackable;
                    swap.holding = false;
                    amount = swap.amount;
                    empty = false;
                    UpdateSlot();
                }
                else
                {
                    if (!swap.solid)
                    {
                        item = swap.item;
                        liquidSP = swap.liquidSPR;
                        col = swap.col;
                        solid = swap.solid;
                        Itemname = swap.itemname;
                        type = swap.itemType;
                        description = swap.desription;
                        icon = swap.icon;
                        stackable = swap.stackable;
                        swap.holding = false;
                        amount = swap.amount;
                        empty = false;

                        sloticonGO.GetComponent<Image>().enabled = true;
                        sloticonGO.GetComponent<Image>().sprite = liquidCube;
                        sloticonGO.GetComponent<Image>().color = col;
                    }
                    else
                    {
                        if (!nosolid)
                        {
                            item = swap.item;
                            liquidSP = swap.liquidSPR;
                            col = swap.col;
                            solid = swap.solid;
                            Itemname = swap.itemname;
                            type = swap.itemType;
                            description = swap.desription;
                            icon = swap.icon;
                            stackable = swap.stackable;
                            swap.holding = false;
                            amount = swap.amount;
                            empty = false;
                            sloticonGO.GetComponent<Image>().enabled = true;
                            sloticonGO.GetComponent<Image>().sprite = icon;
                            sloticonGO.GetComponent<Image>().color = Color.white;
                        }
                    }
                }
            }
        }
    }

    public void takeone()
    {
        if (amount > 1)
        {
            if (!swap.holding)
            {
                if (!empty)
                {
                    swap.grabslot(item, Itemname, description, 1, icon, stackable, col, solid, liquidSP);
                    amount--;
                    UpdateSlot();
                }
            }
            else
            {
                if (Itemname == swap.itemname)
                {
                    amount--;
                    swap.amount++;
                    UpdateSlot();
                }
            }
        }
        else
        {
            if (!swap.holding)
            {
                if (!empty)
                {
                    swap.grabslot(item, Itemname, description, 1, icon, stackable, col, solid, liquidSP);
                    empty = true;
                    clearSlot();
                }
            }
            else
            {
                if (item == swap.item)
                {
                    swap.amount++;
                    empty = true;
                    clearSlot();
                }
            }
        }
    }

    public void UpdateSlot()
    {
        sloticonGO.GetComponent<Image>().enabled = true;
        sloticonGO.GetComponent<Image>().sprite = icon;
        if(item != null)
        {
            col = item.GetComponent<Chemical>().Color;
        }
        if(sloticonGO.childCount != 0)
        {
            liquid.GetComponent<Image>().color = col;
        }
        else
        {
            if (!solid)
            {
                liquid = Instantiate(sloticonGO.gameObject, sloticonGO.transform);
                liquid.GetComponent<Image>().enabled = true;
                liquid.GetComponent<Image>().sprite = liquidSP;
                liquid.GetComponent<Image>().color = col;
            }
        }
    }
}
