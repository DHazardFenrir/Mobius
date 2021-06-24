using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPuzzle : MonoBehaviour
{

   [SerializeField] protected PuzzleStep[] steps;

    private int currentStep;

    private void Start()
    {
        StartStep(steps[0]);
    }

    private void StartStep(PuzzleStep step)
    {
        step.onStepCompleted.Invoke();
    }

    private void CompleteStep(PuzzleStep step)
    {
        step.isCompleted = true;
        step.onStepCompleted.Invoke();

        NextStep();
    }

    private void NextStep()
    {
        currentStep++;
        if (currentStep < steps.Length)
            StartStep(steps[currentStep]);
    }

}
