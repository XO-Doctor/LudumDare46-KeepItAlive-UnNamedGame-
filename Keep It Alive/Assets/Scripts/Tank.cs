using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public float PH = 7;
    public float Temperature = 20;
    public float Pressure = 0;
    public float Hunger = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //change pressure in ienumerator


    public void Inject(Chemical chemical)
    {
        PH += (chemical.PH - 7) * (1 / 7);  //change the ph

        Temperature += chemical.Temperature;
        Temperature *= 0.5f;                //average the temperature



    }
}
