using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class BoxProximity : MonoBehaviour
{
    public string handTag;
    public Color selectionColor;
    

    void switch_cube_color(GameObject cube, Color color){
        if (cube != null )
        {
            cube.GetComponent<Renderer>().material.color = color;
        }
        
    }

    
   
 void OnTriggerEnter(Collider collider)
    {
        ChoiceController.choice = false;
        if (collider.CompareTag(handTag) || collider.CompareTag("Cube") || collider.name == "red_cube")
        {
            GameObject cube = GameObject.FindGameObjectWithTag("Cube");  
            Transform pd = cube.transform.Find("ProximityDetecter");
            BoxCollider bc = pd.GetComponent<BoxCollider>();
            bc.enabled = false;
            switch_cube_color(cube, selectionColor);
            Debug.Log($"Detected hand or cube");
            ChoiceController.choice = false; // this will change the state of choice object in choicecontroller which notifies the server
        }
       
    }



}
