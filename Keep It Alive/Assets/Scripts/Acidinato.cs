using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Acidinato : MonoBehaviour
{
    public bool making;
    public GameObject alkaline;
    public GameObject acidic;
    public Slot acidicSlot;
    public Slot AlkalineSlot;

    public Image AlIm;

    public Sprite alkalinepressed;
    public Sprite acidicpressed;
    public Sprite nonepressed;

    public void highPH()
    {
        //alkaline
        if (!making)
        {
            if (AlkalineSlot.empty)
            {
                Debug.Log("PressAlkaline");
                making = true;
                AlIm.sprite = alkalinepressed;
                StartCoroutine(MakingAlkaline());
            }
        }
    }

    public void lowPH()
    {
        //acidic
        if (!making)
        {
            if (acidicSlot.empty)
            {
                making = true;
                AlIm.sprite = acidicpressed;
                StartCoroutine(MakingAcidic());
            }
        }
    }

    IEnumerator MakingAcidic()
    {
        yield return new WaitForSeconds(2);
        AlIm.sprite = nonepressed;
        making = false;

        Item itemobject = acidic.GetComponent<Item>();
        Chemical itemchem = acidic.GetComponent<Chemical>();

        AddItemAcidic(acidic, itemobject.Name, itemobject.Description, itemobject.Icon, itemobject.Stackable, acidic, itemchem.Color, itemchem.Solid, itemchem.liquidSPRITE);
    }

    IEnumerator MakingAlkaline()
    {

        yield return new WaitForSeconds(2);
        AlIm.sprite = nonepressed;
        making = false;

        Item itemobject = acidic.GetComponent<Item>();
        Chemical itemchem = acidic.GetComponent<Chemical>();

        AddItemAlkaline(alkaline, itemobject.Name, itemobject.Description, itemobject.Icon, itemobject.Stackable, alkaline, itemchem.Color, itemchem.Solid, itemchem.liquidSPRITE);
    }

    public void AddItemAcidic(GameObject itemObject, string Itemname, string ItemDescription, Sprite ItemIcon, bool stackable, GameObject itemGameObject, Color col, bool solid, Sprite lisp)
    {
        Debug.Log("AddAcidic");

        if (acidicSlot.GetComponent<Slot>().empty)
        {
            //add item
            Debug.Log("asasasasa");

            acidicSlot.GetComponent<Slot>().item = itemGameObject;
            acidicSlot.GetComponent<Slot>().Itemname = Itemname;
            acidicSlot.GetComponent<Slot>().icon = ItemIcon;
            acidicSlot.GetComponent<Slot>().description = ItemDescription;
            acidicSlot.GetComponent<Slot>().amount = 1;
            acidicSlot.GetComponent<Slot>().stackable = stackable;
            acidicSlot.GetComponent<Slot>().col = col;
            acidicSlot.GetComponent<Slot>().solid = solid;
            acidicSlot.GetComponent<Slot>().liquidSP = lisp;

            //Set the item as picked up.
            itemObject.GetComponent<Item>().PickedUp = true;

            //Remove it from the scene with script intact, so that we can still modify the values.
            itemGameObject.GetComponent<SpriteRenderer>().enabled = false;
            itemGameObject.GetComponent<Collider2D>().enabled = false;

            //Call the onPickup function for the item, for it do disable any other renderers.

            itemGameObject.GetComponent<Item>().OnPickup();


            acidicSlot.GetComponent<Slot>().UpdateSlot();
            acidicSlot.GetComponent<Slot>().empty = false;

            return;

        }
    }

    public void AddItemAlkaline(GameObject itemObject, string Itemname, string ItemDescription, Sprite ItemIcon, bool stackable, GameObject itemGameObject, Color col, bool solid, Sprite lisp)
    {
        if (acidicSlot.GetComponent<Slot>().empty)
        {
            //add item
            Debug.Log("AddAlkaline");

            AlkalineSlot.GetComponent<Slot>().item = itemGameObject;
            AlkalineSlot.GetComponent<Slot>().Itemname = Itemname;
            AlkalineSlot.GetComponent<Slot>().icon = ItemIcon;
            AlkalineSlot.GetComponent<Slot>().description = ItemDescription;
            AlkalineSlot.GetComponent<Slot>().amount = 1;
            AlkalineSlot.GetComponent<Slot>().stackable = stackable;
            AlkalineSlot.GetComponent<Slot>().col = col;
            AlkalineSlot.GetComponent<Slot>().solid = solid;
            AlkalineSlot.GetComponent<Slot>().liquidSP = lisp;

            //Set the item as picked up.
            itemObject.GetComponent<Item>().PickedUp = true;

            //Remove it from the scene with script intact, so that we can still modify the values.
            itemGameObject.GetComponent<SpriteRenderer>().enabled = false;
            itemGameObject.GetComponent<Collider2D>().enabled = false;

            //Call the onPickup function for the item, for it do disable any other renderers.

            itemGameObject.GetComponent<Item>().OnPickup();


            AlkalineSlot.GetComponent<Slot>().UpdateSlot();
            AlkalineSlot.GetComponent<Slot>().empty = false;

            return;

        }
    }
}
