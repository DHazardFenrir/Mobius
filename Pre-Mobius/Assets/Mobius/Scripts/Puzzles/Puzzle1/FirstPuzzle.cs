using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPuzzle : MonoBehaviour
{
    [SerializeField] PuzzleData puzzleData;

    [SerializeField] bool[] step;

    Inventario inventario;

    private void Start()
    {
        puzzleData = GetComponent<PuzzleData>();
        inventario = FindObjectOfType<Inventario>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            CheckEvents();
        }
    }

    //es m[as que nada para verificar que todo se este llevando a cabo aun cuando se hacen los pasos
    void CheckEvents()
    {
        for(int i=0;i<puzzleData.puzzleEvents.Length;)
        {
            if(puzzleData.puzzleEvents[i].active)
            {
                i++;
            }
            else
            {
                Debug.Log("Aun no se completan todos los eventos");
                break;
            }
            if(i==puzzleData.puzzleEvents.Length)
            {
                puzzleData.puzzleCompleted = true;
            }
        }
        if(puzzleData.puzzleCompleted==true)
        Debug.Log("Se completaron los eventos");
    }

    void CheckSteps()
    {
        for(int i=0;i<step.Length;)
        {
            if(step[0])
            {
                i++;
            }
            else
            {
                Debug.Log("Aun no se completan todos los pasos");
                break;
            }
            if(i==step.Length)
            {
                puzzleData.puzzleCompleted = true;
            }
        }       
    }

    void StepOne()
    {
        //hablar granjero
        step[0] = true;
        CheckSteps();
    }

    void StepTwo()
    {
        //Cerrar presa
        step[1] = true;
        CheckSteps();
    }

    void FinalStep()
    {
        // obtener ofrenda
        if(inventario.inventory.Contains(puzzleData.ofrenda))
        {
            step[3] = true;
        }
        CheckSteps();
    }
}