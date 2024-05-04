using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_IN : MonoBehaviour
{
    public Vector3 position;
    private string cube_tag = "Cube";
    public GameObject new_cube;
    void OnTriggerEnter(Collider collider){

        if (collider.CompareTag(cube_tag))
        {
            Destroy(collider.gameObject);
            Instantiate(new_cube, position, Quaternion.identity);
        }
    }
}
