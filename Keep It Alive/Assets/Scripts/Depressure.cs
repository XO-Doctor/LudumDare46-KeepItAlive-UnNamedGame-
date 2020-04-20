using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Depressure : MonoBehaviour
{
    Tank tank;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            tank.depressurise();
        }
    }
}
