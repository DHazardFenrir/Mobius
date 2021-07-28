using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Columnas : MonoBehaviour, IInteractable
{
    public int num;

    bool active = false;

    PuzzleColumnas manager;

    UsarPocion pocion;

    MeshRenderer meshR;

    private void Start()
    {
        pocion = FindObjectOfType<UsarPocion>();
        manager = FindObjectOfType<PuzzleColumnas>();
        meshR = GetComponent<MeshRenderer>();
        meshR.enabled = false;
    }

    public void Interact()
    {
        ActivarColumna();
    }

    void ActivarColumna()
    {
        Debug.Log("ActivarColumna");
        if(pocion.efectoActivo)
        {
            meshR.enabled = false;
            active = true;
            manager.Clave(num);
        }
    }

    public void DesactivarColumna()
    {
        active = false;
        meshR.enabled = true;
    }

}
