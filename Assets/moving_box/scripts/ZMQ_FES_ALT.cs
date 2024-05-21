using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NetMQ;
using NetMQ.Sockets;
using System.Threading;
using System;

public class ZMQ_FES_ALT : MonoBehaviour
{
    public string server_address = "tcp://*:5556";
    public string FES_parameters = "channel|red|pwm_micros|150|amplitude_mA|20|period_ms|20";
    private volatile bool threadRunning = true;

    private Thread thread;
    private PublisherSocket socket;
    private volatile bool choiceMade = false;

    void Awake()
    {
       
        ChoiceController.OnChoiceStateChanged += ChoiceChanged; 
        thread = new Thread(new ThreadStart(ClientOnThreadPUB)); 
        thread.Start();
    }

    void ClientOnThreadPUB()
    {
        AsyncIO.ForceDotNet.Force();
        using (socket = new PublisherSocket())
        {
            socket.Options.SendHighWatermark = 1000;
            socket.Bind(server_address);
            
            while (threadRunning)
            {
                if (choiceMade)
                {
                    socket.SendMoreFrame("FES").SendFrame(FES_parameters);
                }
                else
                {
                    socket.SendMoreFrame("FES").SendFrame($"false, sent at {DateTime.Now.ToString()}");
                }
                Thread.Sleep(100); // 1-milisecond delay
            }
            
        }
    }

    void ChoiceChanged(bool choiceState)
    {
        choiceMade = choiceState;
    }

    void OnDestroy()
    {
        threadRunning = false;
        if (thread != null && thread.IsAlive)
        {
            thread.Interrupt();
            thread.Join();
        }
        NetMQConfig.Cleanup();
        ChoiceController.OnChoiceStateChanged -= ChoiceChanged; // Unsubscribe to prevent leaks
    }

}