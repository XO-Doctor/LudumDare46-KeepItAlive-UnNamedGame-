using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public float PH = 7;
    public float Temperature = 20;
    public float Pressure = 0;
    public float Hunger = 0;
    public Slot chemSlot;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateTank());
    }

    //change everything in ienumerator
    IEnumerator UpdateTank()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("change settings");
        if(Hunger >= 200 || Hunger <= 0)
        {

        }
        if (Temperature >= 40 || Temperature <= 0)
        {

        }
        if (PH >= 14 || PH <= 0)
        {

        }
        if (Pressure >= 50 || Pressure <= 0)
        {

        }
        StartCoroutine(UpdateTank());
    }

    public void Inject()
    {
        if (chemSlot.item != null)
        {
            Chemical chem = chemSlot.item.GetComponent<Chemical>();
            chemSlot.clearSlot();

            Hunger += chem.hunger;

            PH += chem.PH;  
            PH *= 0.5f;

            Temperature += chem.Temperature;
            Temperature *= 0.5f;                
        }
    }
}
