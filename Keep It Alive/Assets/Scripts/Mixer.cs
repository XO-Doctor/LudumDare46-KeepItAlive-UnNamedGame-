using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mixer : MonoBehaviour
{
    public Slot Input;
    public Slot Output;

    public Image acidible;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Output.empty == false)
        {
            Chemical output = Output.item.GetComponent<Chemical>();

            if (output.PH < -2 || output.PH > 2)
            {
                Debug.Log("melt");
                acidible.color = Color.green;
            }
            else
            {
                Debug.Log("no melt");
                acidible.color = Color.red;
            }
        }
        else
        {
            acidible.color = Color.red;
        }
    }

    public void Mix()
    {
        if(Input.empty == false && Output.empty == false)
        {
            if(Input.item.GetComponent<Chemical>() != null && Output.item.GetComponent<Chemical>() != null)
            {
                Chemical input = Input.item.GetComponent<Chemical>();
                Chemical output = Output.item.GetComponent<Chemical>();

                if(output.AddToMixture(input) == true)
                {
                    Input.clearSlot();
                    Output.UpdateSlot();
                }
            }
        }
    }
}
