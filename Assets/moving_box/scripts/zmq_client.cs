using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NetMQ; // the zeromq packages
using NetMQ.Sockets;
using System.Threading;
using System;
public class zmq_client : MonoBehaviour
{
   // public string server_address = "tcp://*:5556"; // tcp://*:5556 for server, tcp://localhost:5556 for client
    public string server_address = "tcp://*:5556";
    public string FES_parameters = "channel|red|pwm_micros|150|amplitude_mA|20|period_ms|20";
    public string FES_parameters_OFF = "channel|red|pwm_micros|0|amplitude_mA|0|period_ms|0";
    private volatile bool thread_running_bool = true;
   
    private Thread thread; // otherwise Unity thread freezes

    private bool choiceMade = false; // this bool will be changed by proximity detector 
    

    void Start(){

        ChoiceController.OnChoiceStateChanged += ChoiceChanged; // the way for box and cube colliders to communicate with FES
        

        // Eventually, instead of awake it will work once the trigger has worked
        // here we setup the client (taken from https://zeromq.org/get-started/?language=csharp&library=netmq#)
        // on a thread 

        thread = new Thread(new ThreadStart(clientOnThreadPUB));
        thread.Start();
    }


// receives input from invokation of onchoicemade event in proximity detector class
void ChoiceChanged(bool choiceState)
{
    choiceMade = choiceState;
}
   


    /// <summary>
    // Publisher pattern - send the infor to python subscriber every 10 seconds
   void clientOnThreadPUB()
   {
    AsyncIO.ForceDotNet.Force();
    using (var socket = new PublisherSocket())
    {
        socket.Options.SendHighWatermark = 1000;
        socket.Bind(server_address);
        while (thread_running_bool)
        {
            // choiceMade is a boolean that indicates whether FES stimulation should be on or off
            if (choiceMade == true)
            {
                socket.SendMoreFrame("FES").SendFrame(FES_parameters);
            }

            else
            {
                socket.SendMoreFrame("FES").SendFrame(choiceMade.ToString());
            }
            Thread.Sleep(1000); // sleep 2 seconds
        }
        socket.SendMoreFrame("FES").SendFrame("Stop");
        socket.Close();
    }
    NetMQConfig.Cleanup();
   }


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
}


