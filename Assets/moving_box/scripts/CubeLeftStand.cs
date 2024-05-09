using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CubeLeftStand : MonoBehaviour
{

    bool _cube_left_state;
    public event Action CubeLeftE;

    // property
    public bool cubeLeftState
    {
        get { return _cube_left_state; }
        set {  
            _cube_left_state  =  value;
            if (_cube_left_state ==  true)
            {
                CubeLeftE?.Invoke();
            }
            
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
