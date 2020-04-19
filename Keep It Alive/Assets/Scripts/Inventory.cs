using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    private bool inventoryEnabled;

    private int allSlots;
    private int enabledSlots;
    private GameObject[] slot;

    public GameObject visibleslots;

    void Start()
    {
        allSlots = 5;
        slot = new GameObject[allSlots];

        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = visibleslots.transform.GetChild(i).gameObject;

            if (slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().empty = true;
            }
        }
        // gets all slots in an array
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "item")
        {
            GameObject itempickedup = collision.gameObject;
            Item itemobject = itempickedup.GetComponent<Item>();
            Chemical itemchem = itempickedup.GetComponent<Chemical>();

            AddItem(itempickedup, itemobject.Name, itemobject.Description, itemobject.Icon, itemobject.Stackable, itempickedup, itemchem.Color, itemchem.Solid, itemchem.liquidSPRITE);
        }

        void AddItem(GameObject itemObject, string Itemname, string ItemDescription, Sprite ItemIcon, bool stackable, GameObject itemGameObject, Color col, bool solid, Sprite lisp)
        {
            for (int i = 0; i < allSlots; i++)
            {
                if (slot[i].GetComponent<Slot>().Itemname == Itemname)
                {
                    if (stackable)
                    {
                        slot[i].GetComponent<Slot>().amount++;

                        itemObject.transform.parent = slot[i].transform;
                        Destroy(itemObject);
                        slot[i].GetComponent<Slot>().UpdateSlot();

                        return;
                    }
                }
            }
            for (int i = 0; i < allSlots; i++)
            {
                if (slot[i].GetComponent<Slot>().empty)
                {
                    //add item


                    slot[i].GetComponent<Slot>().item = itemGameObject;
                    slot[i].GetComponent<Slot>().Itemname = Itemname;
                    slot[i].GetComponent<Slot>().icon = ItemIcon;
                    slot[i].GetComponent<Slot>().description = ItemDescription;
                    slot[i].GetComponent<Slot>().amount = 1;
                    slot[i].GetComponent<Slot>().stackable = stackable;
                    slot[i].GetComponent<Slot>().col = col;
                    slot[i].GetComponent<Slot>().solid = solid;
                    slot[i].GetComponent<Slot>().liquidSP = lisp;

                    itemGameObject.SetActive(false);
                    

                    slot[i].GetComponent<Slot>().UpdateSlot();
                    slot[i].GetComponent<Slot>().empty = false;

                    return;

                }
            }
        }

    }
}