using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opening : MonoBehaviour
{
    public GameObject MixerGO;
    public GameObject InjectorGO;
    public GameObject FridgeGO;
    public GameObject CupboardGO;
    public GameObject CupboardtwoGO;
    public GameObject AcidinatoGO;
    public GameObject EtoUse;
    public GameObject Sink;

    public Inventory inven;

    public AudioSource AudioSource;
    public AudioClip Close;



    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Mixer")
        {
            EtoUse.SetActive(true);
            EtoUse.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y + 1, 0);
            if (Input.GetKeyDown(KeyCode.E))
            {
                MixerGO.SetActive(true);
                inven.pickupable = false;
            }
        }
        if (collision.tag == "Injector")
        {
            EtoUse.SetActive(true);
            EtoUse.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y + 1, 0);
            if (Input.GetKeyDown(KeyCode.E))
            {
                InjectorGO.SetActive(true);
                inven.pickupable = false;
            }
        }
        if (collision.tag == "Fridge")
        {
            EtoUse.SetActive(true);
            EtoUse.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y + 1, 0);
            if (Input.GetKeyDown(KeyCode.E))
            {
                FridgeGO.SetActive(true);
                inven.pickupable = false;
            }
        }
        if (collision.tag == "Cupboard")
        {
            EtoUse.SetActive(true);
            EtoUse.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y + 1, 0);
            if (Input.GetKeyDown(KeyCode.E))
            {
                CupboardGO.SetActive(true);
                inven.pickupable = false;

                
            }
        }
        if (collision.tag == "Cupboard2")
        {
            EtoUse.SetActive(true);
            EtoUse.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y + 1, 0);
            if (Input.GetKeyDown(KeyCode.E))
            {
                CupboardtwoGO.SetActive(true);
                inven.pickupable = false;
            }
        }
        if (collision.tag == "Acidinato")
        {
            EtoUse.SetActive(true);
            EtoUse.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y + 1, 0);
            if (Input.GetKeyDown(KeyCode.E))
            {
                AcidinatoGO.SetActive(true);
                inven.pickupable = false;
            }
        }
        if (collision.tag == "Sink")
        {
            EtoUse.SetActive(true);
            EtoUse.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y + 1, 0);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Sink.SetActive(true);
                inven.pickupable = false;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Mixer")
        {
            EtoUse.SetActive(false);
            MixerGO.SetActive(false);
            inven.pickupable = true;
        }
        if (collision.tag == "Injector")
        {
            EtoUse.SetActive(false);
            InjectorGO.SetActive(false);
            inven.pickupable = true;
        }
        if (collision.tag == "Fridge")
        {
            if(FridgeGO.activeSelf)
            {
                AudioSource.clip = Close;
                AudioSource.Play();
            }

            EtoUse.SetActive(false);
            FridgeGO.SetActive(false);
            inven.pickupable = true;

            
        }
        if (collision.tag == "Cupboard")
        {
            if(CupboardGO.activeSelf)
            {
                AudioSource.clip = Close;
                AudioSource.Play();
            }
            EtoUse.SetActive(false);
            CupboardGO.SetActive(false);
            inven.pickupable = true;

            


        }
        if (collision.tag == "Cupboard2")
        {
            if(CupboardtwoGO.activeSelf)
            {
                AudioSource.clip = Close;
                AudioSource.Play();
            }

            EtoUse.SetActive(false);
            CupboardtwoGO.SetActive(false);
            inven.pickupable = true;

            
           
        }
        if (collision.tag == "Acidinato")
        {
            EtoUse.SetActive(false);
            AcidinatoGO.SetActive(false);
            inven.pickupable = true;
        }
        if (collision.tag == "Sink")
        {
            EtoUse.SetActive(false);
            Sink.SetActive(false);
            inven.pickupable = true;
        }
    }
}
