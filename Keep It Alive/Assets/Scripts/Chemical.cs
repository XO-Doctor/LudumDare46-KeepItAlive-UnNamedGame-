using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Effects
{
    Hot,
    Cold,
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
    public float Temperature;
    public float hunger;
    public float PH;

    public bool Solid;

    public Color Color;
    public Sprite liquidSPRITE;

    public float BurnTemperature;
    public float FreezeTemperature;

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

    public override void OnPickup()
    {
        Liquid.enabled = false;
    }

    void RecalculateValues(Chemical chemical)
    {

        Name = "New Mixture";

        float newA = Color.a * Color.a;
        float newR = Color.r * Color.r;
        float newB = Color.b * Color.b;
        float newG = Color.g * Color.g;

        //Recalculate PH value
        PH += (chemical.PH - 7) * (0.2f);

        //Temperature

        Temperature += chemical.Temperature;
        Temperature *= 0.5f;

        //Recalculate the colors
        newR += chemical.Color.r * chemical.Color.r;
        newG += chemical.Color.g * chemical.Color.g;
        newB += chemical.Color.b * chemical.Color.b;

        newA += chemical.Color.a * chemical.Color.a;

        //Add effects


        for (int i = 0; i < chemical.Effects.Count; i++)
        {
            Effects.Add(chemical.Effects[i]);
        }

        for (int i = 0; i < chemical.EffectIntensities.Count; i++)
        {
            EffectIntensities.Add(chemical.EffectIntensities[i]);
        }

        

        newR *= 0.5f;
        newG *= 0.5f;
        newB *= 0.5f;

        newA *= 0.5f;

        Color = new Color(Mathf.Sqrt(newR), Mathf.Sqrt(newG), Mathf.Sqrt(newB), Mathf.Sqrt(newA));

        

        Liquid.color = Color;
       
    }
}
