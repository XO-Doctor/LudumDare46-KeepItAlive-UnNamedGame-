using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionDisplay : MonoBehaviour
{
    public GameObject display;
    public GameObject[] slots;
    private int allSlots;
    public GameObject visibleslots;
    public int selectedslot;
    public Sprite NormalSprite;
    public Sprite SelectedSprite;
    public bool active;
    public Tank tank;

    private void Start()
    {
        allSlots = 5;
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
            if (selectedslot >= 4)
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
                selectedslot = 4;
                slots[selectedslot].GetComponent<Image>().sprite = SelectedSprite;
            }
            else
            {
                selectedslot--;
                slots[selectedslot].GetComponent<Image>().sprite = SelectedSprite;
            }
        }

        if (active)
        {
            if (!slots[selectedslot].GetComponent<Slot>().empty)
            {
                calculate();
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!active)
            {
                active = true;
                display.transform.gameObject.SetActive(true);
                if (!slots[selectedslot].GetComponent<Slot>().empty)
                {
                    calculate();
                }
            }
            else
            {
                active = false;
                display.transform.gameObject.SetActive(false);
            }
        }

    }

    public void calculate()
    {
        for (int i = 0; i < 4; i++)
        {
            if(i == 0)
            {
                display.transform.GetChild(i).GetComponent<Slider>().value = tank.Hunger;
                Transform slider = display.transform.GetChild(i);
                slider.GetChild(0).GetComponent<Slider>().value = (tank.Hunger + slots[selectedslot].GetComponent<Slot>().item.gameObject.GetComponent<Chemical>().hunger);
            }
            if (i == 1)
            {
                display.transform.GetChild(i).GetComponent<Slider>().value = tank.Temperature;
                Transform slider = display.transform.GetChild(i);
                slider.GetChild(0).GetComponent<Slider>().value = (tank.Temperature + slots[selectedslot].GetComponent<Slot>().item.gameObject.GetComponent<Chemical>().Temperature) / 2;
            }
            if (i == 2)
            {
                display.transform.GetChild(i).GetComponent<Slider>().value = tank.PH;
                Transform slider = display.transform.GetChild(i);
                slider.GetChild(0).GetComponent<Slider>().value = (tank.PH + slots[selectedslot].GetComponent<Slot>().item.gameObject.GetComponent<Chemical>().PH) / 2;
            }
        }
    }
}
