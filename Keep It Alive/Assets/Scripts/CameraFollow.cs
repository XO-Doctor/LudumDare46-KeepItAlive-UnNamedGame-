using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Camera;

    private void Update()
    {
        Camera.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 10);
    }

}
