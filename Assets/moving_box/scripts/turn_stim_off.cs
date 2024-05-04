using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn_stim_off : MonoBehaviour
{

    public void TurnOffStim(){
        // to turn off the stimulation we refer to a static Choice Controller class
        ChoiceController.choice = false; // the changing of this variable in turn will trigger change in zmq_client class
        Debug.Log("Turned off 4");
    }
}
