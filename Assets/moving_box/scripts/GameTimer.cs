using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameTimer : MonoBehaviour
{
   // Timer listens to LeftZone, CubeInBox and GetNewCube

   private bool TimerIsOn;
   // timer values should be broadcasted to the python script

   public event Action<float> NewTimerDone; 
   private float current_time;

   public GameObject LeftZone;
   public GameObject InBox;
   public GameObject Res;


   void Awake(){
    TimerIsOn = false;

    LeftZone.GetComponent<CubeLeftStand>().CubeLeftE += StartTime;
    InBox.GetComponent<CubeInBox>().CubeInBoxE += StopTime;
    Res.GetComponent<RestartBtn>().RestartE += StopTimeRestart;
    Debug.Log("I am awake ------------------");

   }


   void FixedUpdate(){
    if  (TimerIsOn){
        current_time += Time.fixedDeltaTime;
    }

   }

   void StartTime(){
    Debug.Log("Time started==========================================================");
    TimerIsOn = true;
   }


   void StopTime(){
    TimerIsOn =  false;
    Debug.Log("Time stopped00000000000000000000000000000000000000");
    NewTimerDone?.Invoke(current_time);
    current_time = 0.0f; // we restart the timer after  sending the thing
   }

    void StopTimeRestart(){
    TimerIsOn =  false;
    current_time = 0.0f;
    Debug.Log("Time stopped----------------------------------");
   }


}
