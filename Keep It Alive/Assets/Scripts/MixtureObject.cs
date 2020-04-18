using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixtureObject : MonoBehaviour
{
    public Chemical[] Chemicals;

    public string Name;
    public string Description;

    public Color Color;

    public Effects[] Effects;
    public int[] EffectIntensities;

    public float PH;

    public float Temperature;

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
            if(PH < 5 || PH > 9)  
            {

                //Can dissolve solid

                if (Chemical.BurnTemperature > Temperature && Chemical.FreezeTemperature < Temperature)
                {
                    //It wont burn or freeze, add the chemical to mixture
                    Chemicals[Chemicals.Length + 1] = Chemical;

                    RecalculateValues();
                    return true;
                }
                else
                {
                    //The chemical will burn or freeze before it can be mixed in.
                    return false;
                }
                

            }
            else
            {
                //cannot dissolve solid, not acidic enough
                return false;
            }
        }
        else
        {
            if(Chemical.BurnTemperature > Temperature && Chemical.FreezeTemperature < Temperature)
            {
                //The chemical can mix, it's not going to evaporate or freeze

                //Add the chemical to mixture
                Chemicals[Chemicals.Length + 1] = Chemical;

                RecalculateValues();

                return true;
            }
            else
            {
                //The chemical will burn or freeze before it can be mixed in.
                return false;
            }
            
        }
    }

    void RecalculateValues()
    {

        float newPH = 7;

        float newA = 0;
        float newR = 0;
        float newB = 0;
        float newG = 0;

        Effects[] effects = new Effects[] { };
        int[] intensities = new int[] { };

        for (int i = 0; i < Chemicals.Length; i++)
        {
            //Recalculate PH value
            newPH += (Chemicals[i].PH - 7) * (1/7);

            //Recalculate the colors
            newR += Chemicals[i].InfluenceColor.r;
            newG += Chemicals[i].InfluenceColor.g;
            newB += Chemicals[i].InfluenceColor.b;

            newA += Chemicals[i].InfluenceColor.a;

            //Add effects
            effects[i] = Chemicals[i].Effect;
            intensities[i] = Chemicals[i].EffectIntensity;
        }

        
        newR = newR * (1 / Chemicals.Length);
        newG = newG * (1 / Chemicals.Length);
        newB = newB * (1 / Chemicals.Length);
        newA = newA * (1 / Chemicals.Length);

        Color = new Color(newR, newG, newB, newA);

        PH = newPH;

        Effects = effects;
        EffectIntensities = intensities;
    }
}


