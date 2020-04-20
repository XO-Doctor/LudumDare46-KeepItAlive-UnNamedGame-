using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;




public class Tank : MonoBehaviour
{
    public float PH = 7;
    public float Temperature = 20;
    public float Pressure = 0;
    public float Hunger = 0;
    public Slot chemSlot;

    public Animator TankAnim;
    public Effects[] effects;
    public int[] intensities;

    public TextMeshPro stats;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateTank());
    }

    //change everything in ienumerator
    IEnumerator UpdateTank()
    {

        yield return new WaitForSeconds(1);

        Hunger -= 1;

        Pressure += 1;

        stats.text = "PH:" + PH + "  " + Temperature + "C  " + Pressure + "Pres  " + Hunger + "Hung  ";

        //Debug.Log("change settings");
        if(Hunger >= 200 || Hunger <= 0)
        {
            //die
        }
        if (Temperature >= 40 || Temperature <= 0)
        {
            //melt or freeze
        }
        if (PH >= 14 || PH <= 0)
        {
            //Disintegrate
        }
        if (Pressure >= 50 || Pressure <= 0)
        {
            //Explode or implode
        }

        for (int i = 0; i < intensities.Length; i++)
        {
            if(intensities[i] < 0)
            {
                intensities[i]--;
            }

            if(intensities[i] >= 0)
            {
                intensities[i] = 0;
                effects[i] = 0;
            }
        }

        for (int i = 0; i < effects.Length; i++)
        {
            if(effects[i] != Effects.None)
            {
                EvaluateEffect(effects[i]);
            }
        }

        StartCoroutine(UpdateTank());
    }

    void EvaluateEffect(Effects Effect)
    {
        if(Effect == Effects.Anger)
        {
            //Make him angry
            PH -= 0.1f;
            Hunger -= 5;
        }
        else if(Effect == Effects.Bloat)
        {
            //raise pressure
            Pressure += 5;
        }
        else if(Effect == Effects.Calm)
        {
            if(PH > 7)
            {
                PH -= 0.1f;
            }
            if (PH < 7)
            {
                PH += 0.1f;
            }
        }
        else if(Effect == Effects.Cold)
        {
            Temperature -= 1;
        }
        else if(Effect == Effects.Dizzy)
        {
            //knock the tank around
        }
        else if(Effect == Effects.Drunk)
        {
            //Knock the tank around really badly
        }
        else if(Effect == Effects.Gas)
        {
            Pressure += 8;
        }
        else if(Effect == Effects.Happy)
        {
            if (PH > 7)
            {
                PH -= 0.1f;
            }
            if (PH < 7)
            {
                PH += 0.1f;
            }

            if (Temperature > 20)
            {
                Temperature -= 1f;
            }
            if (Temperature < 20)
            {
                Temperature += 1f;
            }
        }
        else if(Effect == Effects.Hot)
        {
            Temperature += 1;
        }
        else if(Effect == Effects.Mutate)
        {
            Temperature += Random.Range(-5, 5);
            Hunger -= 8;
        }
        else if(Effect == Effects.Nutrition)
        {
            Hunger += 5;
        }
        else if(Effect == Effects.Pain)
        {
            PH += 0.1f;
        }
        else if(Effect == Effects.Plants)
        {
            //Grow plants
        }
        else if(Effect == Effects.Posion)
        {
            Hunger -= 1;
            Temperature -= 1;
        }
        else if(Effect == Effects.Starve)
        {
            Hunger -= 10;
        }
        
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
            
            for (int i = 0; i < chem.Effects.Count; i++)
            {
                effects[effects.Length + 1] = chem.Effects[i];
                intensities[intensities.Length + 1] = chem.EffectIntensities[i];
            }
        }
    }
}
