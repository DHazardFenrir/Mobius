using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPuzzle : MonoBehaviour
{

    [SerializeField] bool puzzleCompleted;

    [SerializeField] Items ofrenda;

    Inventario inventario;

    private void Start()
    {
        inventario = FindObjectOfType<Inventario>();
    }

 
    public void CerrarPresa()
    {
        //Cerrar presa
    }

    public void FinalStep()
    {
        // obtener ofrenda
        if(inventario.inventory.Contains(ofrenda))
        {
            puzzleCompleted = true;
        }

    }
}