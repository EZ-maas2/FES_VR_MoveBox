using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float x_min, x_max, y, z;
    public GameObject box;
    void Start()
    {
        Instantiate(box, new Vector3(Random.Range(x_min,x_max), y, z), box.transform.localRotation);
    }

  
}
