using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreKeeper  
{
    public static float current_score;
    private bool TimerIsOn = false;
    private static float last_recorded_score;

    void Awake(){
        // here we subscribe to the events that require timer starting or stopping
        // class.event += StartTime
        // class2.event2 += StopTime
    }

    void FixedUpdate(){
        if (TimerIsOn)
        {
            current_score += Time.fixedDeltaTime;

        }
    }

    void StartTime(){
        TimerIsOn = true;
    }

    void StopTime(){
        TimerIsOn = false;
        last_recorded_score  = current_score;
        current_score = 0.0f;
    }
}
