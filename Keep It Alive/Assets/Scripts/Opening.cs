using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opening : MonoBehaviour
{
    public GameObject MixerGO;
    public GameObject InjectorGO;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Mixer")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                MixerGO.SetActive(true);
            }
        }
        if (collision.tag == "Injector")
        {
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
            MixerGO.SetActive(false);
        }
        if (collision.tag == "Injector")
        {
            InjectorGO.SetActive(false);
        }
    }
}
