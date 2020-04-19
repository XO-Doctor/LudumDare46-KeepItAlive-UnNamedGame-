using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opening : MonoBehaviour
{
    public GameObject MixerGO;
    public GameObject InjectorGO;
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
    }
}
