using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opening : MonoBehaviour
{
    public GameObject MixerGO;
    public GameObject InjectorGO;
    public GameObject FridgeGO;
    public GameObject CupboardGO;
    public GameObject Cupboard2GO;
    public GameObject EtoUse;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Mixer")
        {
            EtoUse.SetActive(true);
            EtoUse.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y + 1, 0);
            if (Input.GetKeyDown(KeyCode.E))
            {
                MixerGO.SetActive(true);
            }
        }
        if (collision.tag == "Injector")
        {
            EtoUse.SetActive(true);
            EtoUse.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y + 1, 0);
            if (Input.GetKeyDown(KeyCode.E))
            {
                InjectorGO.SetActive(true);
            }
        }
        if (collision.tag == "Fridge")
        {
            EtoUse.SetActive(true);
            EtoUse.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y + 1, 0);
            if (Input.GetKeyDown(KeyCode.E))
            {
                FridgeGO.SetActive(true);
            }
        }
        if (collision.tag == "Cupboard")
        {
            EtoUse.SetActive(true);
            EtoUse.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y + 1, 0);
            if (Input.GetKeyDown(KeyCode.E))
            {
                CupboardGO.SetActive(true);
            }
        }
        if (collision.tag == "Cupboard 2")
        {
            EtoUse.SetActive(true);
            EtoUse.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y + 1, 0);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Cupboard2GO.SetActive(true);
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Mixer")
        {
            EtoUse.SetActive(false);
            MixerGO.SetActive(false);
        }
        if (collision.tag == "Injector")
        {
            EtoUse.SetActive(false);
            InjectorGO.SetActive(false);
        }
        if (collision.tag == "Fridge")
        {
            EtoUse.SetActive(false);
            FridgeGO.SetActive(false);
        }
        if (collision.tag == "Cupboard")
        {
            EtoUse.SetActive(false);
            CupboardGO.SetActive(false);
        }
        if (collision.tag == "Cupboard 2")
        {
            EtoUse.SetActive(false);
            Cupboard2GO.SetActive(false);
        }
    }
}
