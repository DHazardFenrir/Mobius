using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Columnas : MonoBehaviour, IInteractable
{
    public int num;

    bool active = false;

    PuzzleColumnas manager;

    [SerializeField]UsarPocion pocion;

    MeshRenderer meshR;

    [SerializeField] AudioSource audio;

    private void Start()
    {
        manager = FindObjectOfType<PuzzleColumnas>();
        meshR = GetComponent<MeshRenderer>();
        meshR.enabled = false;
        
    }

    public void Interact()
    {
        if (active==false)
            ActivarColumna();
        else
            Debug.Log("Ya esta activada");

        
    }

    void ActivarColumna()
    {
        Debug.Log("ActivarColumna");
        if(pocion.efectoActivo)
        {
            meshR.enabled = false;
            if (audio != null)
            {
                audio.Play();
            }
            active = true;
            manager.Clave(num);
            GetComponent<BoxCollider>().enabled = false;

        }
    }

    public void DesactivarColumna()
    {
        active = false;
        meshR.enabled = true;
        GetComponent<BoxCollider>().enabled = true;

    }

}
