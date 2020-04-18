using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalObject : MonoBehaviour
{
    public Chemical chemical;

    //all of the current attributes of this specific chemical
    public float PH;
    public float Temperature;

    // Start is called before the first frame update
    void Start()
    {
        PH = chemical.PH;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
