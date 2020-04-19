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

    public Transform sloticonGO;
    public Text text;
    public Sprite icon;
    public bool stackable;

    private void Start()
    {
        Button button = this.GetComponent<Button>();
        sloticonGO = transform.GetChild(0);
        text = transform.GetChild(1).GetComponent<Text>();
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
        text.text = 0.ToString();
        icon = null;
        sloticonGO.GetComponent<Image>().enabled = false;
    }

    public void select()
    {
        if (!empty)
        {
            if (!swap.holding)
            {
                swap.grabslot(item, Itemname, description, amount, icon, stackable);
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
                
                item = swap.item;
                GameObject parenteditem = Instantiate(item, transform);
                if(transform.childCount > 2)
                {
                    Destroy(transform.GetChild(2).gameObject);
                }
                parenteditem.SetActive(false);
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
                    swap.grabslot(item, Itemname, description, 1, icon, stackable);
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
                    swap.grabslot(item, Itemname, description, 1, icon, stackable);
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
        text.text = amount.ToString();
    }
}
