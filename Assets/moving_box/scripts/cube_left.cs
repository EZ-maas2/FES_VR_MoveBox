using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class cube_left : MonoBehaviour
{

    bool _cube_left_state;
    public event Action<bool> OnCubeStateChanged;

    // property
    public bool cubeLeftState
    {
        get { return _cube_left_state; }
        set {  
            _cube_left_state  =  value;
            OnCubeStateChanged?.Invoke(_cube_left_state);
            }
    }

    void Awake()
    {
        _cube_left_state = false;
    }

    // Start is called before the first frame update
   void OnTriggerExit(Collider collider){
    Debug.Log($"We started tracking trigger exit, {collider.name}");


    if (collider.tag == "Cube" || collider.name == "red_cube")
    {
        Debug.Log("Cube has left the premises");
        cubeLeftState = true;
    }
   }
}
