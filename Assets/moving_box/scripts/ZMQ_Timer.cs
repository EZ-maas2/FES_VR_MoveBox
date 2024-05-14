using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NetMQ; // the zeromq packages
using NetMQ.Sockets;
using System.Threading;
using System;

public class ZMQ_Timer : MonoBehaviour
{
   // public string server_address = "tcp://*:5556"; // tcp://*:5556 for server, tcp://localhost:5556 for client
    public string server_address = "tcp://*:5557";
    private volatile bool thread_running_bool = true;
    public string SCENE_NAME = "No Name";
   
    private Thread thread; // otherwise Unity thread freezes
    private PublisherSocket socket;

    
    public GameObject GameTimer;
    private volatile bool newTimer  =  false;
    private float current_time;
    


    void Awake(){

        // Subscribe to ChoiceController and GameTime
        //timer = new GameTimer();
        GameTimer.GetComponent<GameTimer>().NewTimerDone += GetTimer;

        // setup the ZMQ communicatiopn on thread (taken from https://zeromq.org/get-started/?language=csharp&library=netmq#)
        thread = new Thread(new ThreadStart(clientOnThreadPUB)); 
        thread.Start();
    }

// ----------------------------------------------------------------------------------

// Publisher pattern - send the infor to python subscriber every 10 seconds
   void clientOnThreadPUB()
   {
    AsyncIO.ForceDotNet.Force();
    socket = new PublisherSocket();
    socket.Options.SendHighWatermark = 1000;
    socket.Bind(server_address);
    socket.SendMoreFrame("Timer").SendFrame(SCENE_NAME);

    while (thread_running_bool)
    {
        if(newTimer)
        {
            socket.SendMoreFrame("Timer").SendFrame(current_time.ToString());
            current_time = 0.0f;
            newTimer  = false;
        }
    }

    socket.SendMoreFrame("Timer").SendFrame("Stop");
    socket.Close();
   }

// ----------------------------------------------------------------------------------

  

   void OnDestroy(){
    thread_running_bool = false;
    if (thread != null && thread.IsAlive)
    {   
        thread.Interrupt(); // Attempt to interrupt the thread before joining
        thread.Join();
    }
    thread = null;
    NetMQConfig.Cleanup();
   }

// ----------------------------------------------------------------------------------

    void GetTimer(float time){
        current_time = time;
        newTimer =true;
    }


// ----------------------------------------------------------------------------------
}

