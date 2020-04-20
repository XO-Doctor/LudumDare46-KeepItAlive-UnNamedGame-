using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItemTo : MonoBehaviour
{
    public GameObject[] slot;

    public GameObject[] storageItems;

    void Start()
    {

        for (int i = 0; i < storageItems.Length; i++)
        {
            GameObject itempickedup = storageItems[i];
            Item itemobject = itempickedup.GetComponent<Item>();
            Chemical itemchem = itempickedup.GetComponent<Chemical>();

            AddItem(itempickedup, itemobject.Name, itemobject.Description, itemobject.Icon, itemobject.Stackable, itempickedup, itemchem.Color, itemchem.Solid, itemchem.liquidSPRITE);
        }

    }

    public void AddItem(GameObject itemObject, string Itemname, string ItemDescription, Sprite ItemIcon, bool stackable, GameObject itemGameObject, Color col, bool solid, Sprite lisp)
    {
        for (int i = 0; i < storageItems.Length; i++)
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

                //Set the item as picked up.
                itemObject.GetComponent<Item>().PickedUp = true;

                //Remove it from the scene with script intact, so that we can still modify the values.
                itemGameObject.GetComponent<SpriteRenderer>().enabled = false;
                itemGameObject.GetComponent<Collider2D>().enabled = false;

                //Call the onPickup function for the item, for it do disable any other renderers.

                itemGameObject.GetComponent<Item>().OnPickup();


                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().empty = false;

                return;

            }
        }
    }
}
