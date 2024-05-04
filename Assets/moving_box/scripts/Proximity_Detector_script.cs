using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Proximity_Detector_script : MonoBehaviour
{
    public string handTag;
    public bool messageOnChoice;
    public float duration_till_chosen = 0.5F;

    public Color originalColor = Color.red;
    public Color selectionColor = Color.green;
    public GameObject cube;
    
    private float timeElapsed = 0; // KEEPS TRACK HOW LONG THE HAND IS IN PROXIMITY WITH GRABBABLE OBJECT

    public event Action<bool> OnChoiceMade; // event that notifies other objects that the hand spent x seconds in proximity witgh grabbale


    void switch_cube_color(GameObject cube, Color color){
        if (cube != null )
        {
            cube.GetComponent<Renderer>().material.color = color;
        }
        
    }


    void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag(handTag))
        {
            timeElapsed += Time.deltaTime;
        }

        if (timeElapsed >= duration_till_chosen)
        {
            timeElapsed = 0;
            switch_cube_color(cube, selectionColor);
            ChoiceController.choice = messageOnChoice; // this will change the state of choice object in choicecontroller which notifies the server
        }

    }


    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag(handTag)){
            timeElapsed = 0;
            switch_cube_color(cube, originalColor);
        }
    }


}
