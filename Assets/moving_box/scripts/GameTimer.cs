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
   private CubeLeftStand LeftZone;
   private CubeInBox InBox;
   private RestartBtn Res;


   void Awake(){
    TimerIsOn = false;


    LeftZone.CubeLeftE += StartTime;
    InBox.CubeInBoxE += StopTime;
    Res.RestartE += StopTimeRestart;

   }


   void FixedUpdate(){
    if  (TimerIsOn){
        current_time += Time.fixedDeltaTime;
    }

   }

   void StartTime(){
    Debug.Log("Time started");
    TimerIsOn = true;
   }


   void StopTime(){
    TimerIsOn =  false;
    Debug.Log("Time stopped");
    NewTimerDone?.Invoke(current_time);
    current_time = 0.0f; // we restart the timer after  sending the thing
   }

    void StopTimeRestart(){
    TimerIsOn =  false;
    Debug.Log("Time stopped");
   }


}
