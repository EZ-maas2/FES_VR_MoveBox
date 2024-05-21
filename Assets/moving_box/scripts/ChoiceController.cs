using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


// This class keeps the master copy of the state
public static class ChoiceController 
{
    private static bool _choice = false;
    public static event Action<bool> OnChoiceStateChanged;
    

    public static bool choice
    {
        get{
            return _choice;
        }

        set{
            _choice = value;
            OnChoiceStateChanged?.Invoke(_choice);
            Debug.Log($"Set choice to {_choice}, {DateTime.Now}");
        }
    }
}
