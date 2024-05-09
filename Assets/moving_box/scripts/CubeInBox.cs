using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CubeInBox : MonoBehaviour
{
    public Vector3 position;
    private string cube_tag = "Cube";
    public GameObject new_cube;
    public event  Action CubeInBoxE;


    void OnTriggerEnter(Collider collider){

        if (collider.CompareTag(cube_tag))
        {
            Destroy(collider.gameObject);
            Instantiate(new_cube, position, Quaternion.identity);
            CubeInBoxE?.Invoke();
        }
    }
}
