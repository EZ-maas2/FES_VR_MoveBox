using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartBtn : MonoBehaviour
{
    public GameObject cube_model;
    public Vector3 spawn_loc;
    void RestartLvl()
    {
        GameObject old_cube = GameObject.FindGameObjectWithTag("Cube");
        Destroy(old_cube);
        Instantiate(cube_model, spawn_loc, Quaternion.identity);
    }
}
