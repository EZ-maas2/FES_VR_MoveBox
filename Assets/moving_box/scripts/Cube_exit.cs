using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cube_exit : MonoBehaviour
{
    public string cubeName;
    private event Action CubeLeftZone;
    void OnTriggerExit(Collider collider){
        if (collider.gameObject.name == cubeName)
        {
           CubeLeftZone?.Invoke(); // this will notify the time keeper class
        }

    }
}

