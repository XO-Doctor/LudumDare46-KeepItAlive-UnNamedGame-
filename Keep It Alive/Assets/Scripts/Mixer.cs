using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mixer : MonoBehaviour
{
    public Slot Input;
    public Slot Output;
    public Slot ByProduct;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
