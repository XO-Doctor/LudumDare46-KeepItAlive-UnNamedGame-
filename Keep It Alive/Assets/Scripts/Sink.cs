using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sink : MonoBehaviour
{
    public bool making;
    public GameObject HotWater;
    public GameObject ColdWater;
    public Slot RSlot;

    public void MakeHot()
    {
        //alkaline
        if (!making)
        {
            if (RSlot.empty)
            {
                Debug.Log("PressAlkaline");
                making = true;
                StartCoroutine(MakingHot());
            }
        }
    }

    public void Addcold()
    {
        //acidic
        if (!making)
        {
            if (RSlot.empty)
            {
                making = true;
                StartCoroutine(MakingCold());
            }
        }
    }

    IEnumerator MakingCold()
    {
        yield return new WaitForSeconds(2);
        making = false;

        Item itemobject = ColdWater.GetComponent<Item>();
        Chemical itemchem = ColdWater.GetComponent<Chemical>();

        AddCold(ColdWater, itemobject.Name, itemobject.Description, itemobject.Icon, itemobject.Stackable, ColdWater, itemchem.Color, itemchem.Solid, itemchem.liquidSPRITE);
    }

    IEnumerator MakingHot()
    {

        yield return new WaitForSeconds(2);
        making = false;

        Item itemobject = HotWater.GetComponent<Item>();
        Chemical itemchem = HotWater.GetComponent<Chemical>();

        AddHot(HotWater, itemobject.Name, itemobject.Description, itemobject.Icon, itemobject.Stackable, HotWater, itemchem.Color, itemchem.Solid, itemchem.liquidSPRITE);
    }

    public void AddHot(GameObject itemObject, string Itemname, string ItemDescription, Sprite ItemIcon, bool stackable, GameObject itemGameObject, Color col, bool solid, Sprite lisp)
    {
        Debug.Log("AddAcidic");

        if (RSlot.GetComponent<Slot>().empty)
        {
            //add item
            Debug.Log("asasasasa");

            RSlot.GetComponent<Slot>().item = itemGameObject;
            RSlot.GetComponent<Slot>().Itemname = Itemname;
            RSlot.GetComponent<Slot>().icon = ItemIcon;
            RSlot.GetComponent<Slot>().description = ItemDescription;
            RSlot.GetComponent<Slot>().amount = 1;
            RSlot.GetComponent<Slot>().stackable = stackable;
            RSlot.GetComponent<Slot>().col = col;
            RSlot.GetComponent<Slot>().solid = solid;
            RSlot.GetComponent<Slot>().liquidSP = lisp;

            //Set the item as picked up.
            itemObject.GetComponent<Item>().PickedUp = true;

            //Remove it from the scene with script intact, so that we can still modify the values.
            itemGameObject.GetComponent<SpriteRenderer>().enabled = false;
            itemGameObject.GetComponent<Collider2D>().enabled = false;

            //Call the onPickup function for the item, for it do disable any other renderers.

            itemGameObject.GetComponent<Item>().OnPickup();


            RSlot.GetComponent<Slot>().UpdateSlot();
            RSlot.GetComponent<Slot>().empty = false;

            return;

        }
    }

    public void AddCold(GameObject itemObject, string Itemname, string ItemDescription, Sprite ItemIcon, bool stackable, GameObject itemGameObject, Color col, bool solid, Sprite lisp)
    {
        if (RSlot.GetComponent<Slot>().empty)
        {
            //add item
            Debug.Log("AddAlkaline");

            RSlot.GetComponent<Slot>().item = itemGameObject;
            RSlot.GetComponent<Slot>().Itemname = Itemname;
            RSlot.GetComponent<Slot>().icon = ItemIcon;
            RSlot.GetComponent<Slot>().description = ItemDescription;
            RSlot.GetComponent<Slot>().amount = 1;
            RSlot.GetComponent<Slot>().stackable = stackable;
            RSlot.GetComponent<Slot>().col = col;
            RSlot.GetComponent<Slot>().solid = solid;
            RSlot.GetComponent<Slot>().liquidSP = lisp;

            //Set the item as picked up.
            itemObject.GetComponent<Item>().PickedUp = true;

            //Remove it from the scene with script intact, so that we can still modify the values.
            itemGameObject.GetComponent<SpriteRenderer>().enabled = false;
            itemGameObject.GetComponent<Collider2D>().enabled = false;

            //Call the onPickup function for the item, for it do disable any other renderers.

            itemGameObject.GetComponent<Item>().OnPickup();


            RSlot.GetComponent<Slot>().UpdateSlot();
            RSlot.GetComponent<Slot>().empty = false;

            return;

        }
    }
}
