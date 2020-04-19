using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class useItems : MonoBehaviour
{
    public Item item;
    public GameObject[] slots;
    private int allSlots;
    public GameObject visibleslots;
    public int selectedslot;
    public Sprite SelectedSprite;
    public Sprite NormalSprite;
    public bool mousehold;
    public GameObject selecteditem;

    private void Start()
    {
        allSlots = 10;
        slots = new GameObject[allSlots];

        for (int i = 0; i < allSlots; i++)
        {
            slots[i] = visibleslots.transform.GetChild(i).gameObject;
        }
    }

    public void Update()
    {

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            slots[selectedslot].GetComponent<Image>().sprite = NormalSprite;
            if (selectedslot >= 9)
            {
                selectedslot = 0;
                slots[selectedslot].GetComponent<Image>().sprite = SelectedSprite;
            }
            else
            {
                selectedslot++;
                slots[selectedslot].GetComponent<Image>().sprite = SelectedSprite;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            slots[selectedslot].GetComponent<Image>().sprite = NormalSprite;
            if (selectedslot <= 0)
            {
                selectedslot = 9;
                slots[selectedslot].GetComponent<Image>().sprite = SelectedSprite;
            }
            else
            {
                selectedslot--;
                slots[selectedslot].GetComponent<Image>().sprite = SelectedSprite;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            useitem();
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (selecteditem != null)
            {
                Destroy(selecteditem);
            }
        }
        if (Input.GetMouseButton(0))
        {
            mousehold = true;
        }
        else
        {
            mousehold = false;
        }

        void useitem()
        {
            if (!slots[selectedslot].GetComponent<Slot>().empty)
            {
                GameObject go = slots[selectedslot].transform.GetChild(2).gameObject;
                Item item = go.GetComponent<Item>();
               
                
            }
        }
    }
}
