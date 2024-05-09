using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NetMQ; // the zeromq packages
using NetMQ.Sockets;
using System.Threading;
using System;

public class ZMQ : MonoBehaviour
{
   // public string server_address = "tcp://*:5556"; // tcp://*:5556 for server, tcp://localhost:5556 for client
    public string server_address = "tcp://*:5556";
    public string FES_parameters = "channel|red|pwm_micros|150|amplitude_mA|20|period_ms|20";
    public string FES_parameters_OFF = "channel|red|pwm_micros|0|amplitude_mA|0|period_ms|0";
    private volatile bool thread_running_bool = true;
   
    private Thread thread; // otherwise Unity thread freezes
    private PublisherSocket socket;

    private bool choiceMade = false; // this bool will be changed by proximity detector 
    private GameTimer timer;
    
    

    void Awake(){

        // Subscribe to ChoiceController and GameTime
        ChoiceController.OnChoiceStateChanged += ChoiceChanged; 
        timer.NewTimerDone += TimerMessage;

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

    while (thread_running_bool)
    {
        ChoiceMessage(); // choiceMade is a boolean that indicates whether FES stimulation should be on or off
        Thread.Sleep(1000); // sleep 2 seconds
    }

    socket.SendMoreFrame("FES").SendFrame("Stop");
    socket.Close();
    
    NetMQConfig.Cleanup();
   }

// ----------------------------------------------------------------------------------

    // receives input from invokation of onchoicemade event in proximity detector class
    void ChoiceChanged(bool choiceState)
    {
        choiceMade = choiceState;
    }

   void OnDestroy(){
    ChoiceController.OnChoiceStateChanged -= ChoiceChanged;
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

    void TimerMessage(float time){
        byte[] time_b = BitConverter.GetBytes(time);
        socket.SendMoreFrame("Timer").SendFrame(time_b);
    }

// ----------------------------------------------------------------------------------

   void ChoiceMessage()
   {
     
            if (choiceMade)
            {
                socket.SendMoreFrame("FES").SendFrame(FES_parameters);
            }

            else
            {
                socket.SendMoreFrame("FES").SendFrame(choiceMade.ToString());
            }

   }

   // ----------------------------------------------------------------------------------
}


