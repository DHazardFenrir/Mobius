using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class PuzzleStep 
{
    public string stepName;

    public bool isCompleted;

    public UnityEvent onStepStarted;

    public UnityEvent onStepCompleted;   

    //public int[] requiredSteps;

}
