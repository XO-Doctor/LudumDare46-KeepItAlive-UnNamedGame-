using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixtureObject : MonoBehaviour
{
    public Chemical[] Chemicals;

    public string Name;
    public string Description;

    public Color Color;

    public string[] Effects;

    public float PH;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool AddToMixture(Chemical Chemical)     //Returns false if failed
    {
        //Test if solid
        if(Chemical.Solid == true)
        {
            if(PH < 5)  
            {
                //can dissolve solid
            }
            else
            {
                //cannot dissolve solid, not acidic enough
                return false;
            }
        }
        else
        {

        }
    }

    void RecalculateValues()
    {

    }
}


