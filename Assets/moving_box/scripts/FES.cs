using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FES : MonoBehaviour
{

    public GameObject TestGameObject;
    public float x,y,z;
    public GameObject red_cube;
    
    // Subscribe to the selection indication
    void Awake()
    {
        Transform proximityDetector  = red_cube.transform.Find("ProximityDetector");
        Proximity_Detector_script proximityDetector_s = proximityDetector.GetComponent<Proximity_Detector_script>();
        proximityDetector_s.OnChoiceMade += DeliverStimulation; // subscribe Deliver stimulation function to hoice made
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void DeliverStimulation(bool deliver)
    {
        // this is triggered when the choice of grabbing the object is made
        if (deliver)
        {
            Instantiate(TestGameObject, new Vector3(x,y,z), Quaternion.identity);
        }
    }
}
