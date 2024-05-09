using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; // for writing in the file

// public static class ScoreKeeper  
// {
//     public static float current_score;
//     private static bool TimerIsOn = false;
//     private static float last_recorded_score;
//     private static string filePath = "record.txt";

//     private static cube_left  cb;

//     Main();

//     static void Main()
//        { cb =  new cube_left(); 
//         cb.OnCubeStateChanged  += ReactToCubeLeavingStand;
//         File.AppendAllText(filePath, $"started a new recording {DateTime.Now}");

//         if (TimerIsOn)
//             {
//                 current_score += Time.fixedDeltaTime;

//             }}


//     // static void FixedUpdate(){
//     //     if (TimerIsOn)
//     //     {
//     //         current_score += Time.fixedDeltaTime;

//     //     }
//     // }

//     static void StartTime(){
//         Debug.Log("starting the timer");
//         TimerIsOn = true;

//         File.AppendAllText(filePath, $"Started the timer at {DateTime.Now} ");
//     }

//     static  void StopTime(){
//         TimerIsOn = false;
//         last_recorded_score  = current_score;
//         current_score = 0.0f;
//         File.AppendAllText(filePath, $"Stopped the timer at {DateTime.Now} ");
//     }

//     static void ReactToCubeLeavingStand(bool cubeLeft){
//         Debug.Log($"Cube left funct, cubeLedft  is {cubeLeft}");
//         if  (cubeLeft)
//         {
//             StartTime();
//         }
//         else{
//             StopTime();
//         }
//     }
// }
