using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Effects
{
    Mutate,
    Posion,
    Drunk,
    Happy,
    Calm,
    Anger,
    Dizzy,
    Nutrition,
    Gas,
    Plants,
    Starve,
    Bloat,
    Pain
}

public class Chemical : Item
{
    public bool Solid;
    public float PH;
    public Color Color;
    public Sprite liquidSPRITE;

    public float BurnTemperature;
    public float FreezeTemperature;

    public float Temperature;

    public List<Effects> Effects = new List<Effects>();
    public List<int> EffectIntensities = new List<int>();
    public SpriteRenderer Liquid;



    // Start is called before the first frame update
    void Start()
    {
        Liquid.color = Color;
    }

    // Update is called once per frame
    void Update()
    {

    }



    public override bool AddToMixture(Chemical Chemical)     //Returns false if failed
    {
        //Test if solid
        if (Chemical.Solid == true)
        {
            if (PH < 5 || PH > 9)
            {

                //Can dissolve solid

                if (Chemical.BurnTemperature > Temperature && Chemical.FreezeTemperature < Temperature)
                {
                    //It wont burn or freeze, add the chemical to mixture

                    RecalculateValues(Chemical);
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
            if (Chemical.BurnTemperature > Temperature && Chemical.FreezeTemperature < Temperature)
            {
                //The chemical can mix, it's not going to evaporate or freeze

                //Add the chemical to mixture
                RecalculateValues(Chemical);

                return true;
            }
            else
            {
                //The chemical will burn or freeze before it can be mixed in.
                return false;
            }

        }
    }

    void RecalculateValues(Chemical chemical)
    {

        Name = "New Mixture";

        float newPH = 7;

        float newA = 0;
        float newR = 0;
        float newB = 0;
        float newG = 0;

        //Recalculate PH value
        newPH += (chemical.PH - 7) * (1 / 7);

        //Recalculate the colors
        newR += chemical.Color.r;
        newG += chemical.Color.g;
        newB += chemical.Color.b;

        newA += chemical.Color.a;

        //Add effects


        for (int i = 0; i < chemical.Effects.Count; i++)
        {
            Effects.Add(chemical.Effects[i]);
        }

        for (int i = 0; i < chemical.EffectIntensities.Count; i++)
        {
            EffectIntensities.Add(chemical.EffectIntensities[i]);
        }

        

        newR = newR * 0.5f;
        newG = newG * 0.5f;
        newB = newB * 0.5f;
        newA = newA * 0.5f;

        Color = new Color(newR, newG, newB, newA);

        PH = newPH;

        Liquid.color = Color;
       
    }
}
