using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsarPocion : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject[] runas;

    [SerializeField] Items pocionItem;
    public bool efectoActivo { get; private set; } = false;
    [SerializeField] float duracionPocion;

    private LightingManager lM;

    PuzzleColumnas manager;
    
    [SerializeField,Range(0,600)] float horaRequerida;

    Inventario inventory;

    [SerializeField] AudioSource audio;


    private void Start()
    {
        lM = FindObjectOfType<LightingManager>();
        inventory = FindObjectOfType<Inventario>();
        manager = FindObjectOfType<PuzzleColumnas>();
        
    }

    void ActivarEfecto()
    {
        Debug.Log("ActivarEfecto");
        efectoActivo = true;
        Debug.Log("Usando pocion");
        if (audio != null)
        {
            audio.Play();
        }
        for (int i=0;i<runas.Length;i++)
        {
            runas[i].GetComponent<MeshRenderer>().enabled=true;
            runas[i].GetComponent<BoxCollider>().enabled = true;
        }
        GetComponent<BoxCollider>().enabled = false;
    }

    void DesactivarEfecto()
    {
        efectoActivo = false;

        for (int i = 0; i < runas.Length; i++)
        {
            runas[i].GetComponent<MeshRenderer>().enabled = false;
            runas[i].GetComponent<BoxCollider>().enabled = false;

        }
        manager.ResetearClave();
        GetComponent<BoxCollider>().enabled = true;
        Debug.Log("Se acaba la pocion");
    }

    IEnumerator duracion()
    {
        Debug.Log("Duracion");

        yield return new WaitForSeconds(duracionPocion);
        DesactivarEfecto();
    }

    public void Interact()
    {
        if (lM.timeToGet >= horaRequerida && inventory.inventory.Contains(pocionItem) && efectoActivo == false)
               {                
                    ActivarEfecto();
                    StartCoroutine(duracion());
               }
    }


   

}
