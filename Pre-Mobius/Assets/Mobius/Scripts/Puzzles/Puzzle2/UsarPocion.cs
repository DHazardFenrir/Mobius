using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsarPocion : MonoBehaviour
{
    [SerializeField] MeshRenderer[] runas;

    [SerializeField] Items pocionItem;
    public bool efectoActivo { get; private set; } = false;
    [SerializeField] float duracionPocion;

    private LightingManager lM;

    PuzzleColumnas manager;
    
    [SerializeField,Range(0,600)] float horaRequerida;

    Inventario inventory;

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

        for(int i=0;i<runas.Length;i++)
        {
            runas[i].enabled=true;
        }
    }

    void DesactivarEfecto()
    {
        efectoActivo = false;

        for (int i = 0; i < runas.Length; i++)
        {
            runas[i].enabled=false;
        }
        manager.ResetearClave();
    }

    IEnumerator duracion()
    {
        Debug.Log("Duracion");

        yield return new WaitForSeconds(duracionPocion);
        DesactivarEfecto();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Presiona K para usar la poción");
            if (Input.GetKeyDown(KeyCode.K))
            {
                if (lM.timeToGet >= horaRequerida && inventory.inventory.Contains(pocionItem) && efectoActivo==false)
                {                
                    ActivarEfecto();
                    StartCoroutine(duracion());
                }
                else
                {
                    if(lM.timeToGet< horaRequerida)
                    {
                        Debug.Log("No es hora de la hora");
                    }
                    
                    if(inventory.inventory.Contains(pocionItem))
                    {
                        Debug.Log("Hay pocion");
                    }
                    else
                    {
                        Debug.Log("No hay pocion");
                    }

                    if(efectoActivo)
                    {
                        Debug.Log("Efecto activo");
                    }
                    else
                    {
                        Debug.Log("Efecto no activo");
                    }
                }
            }
        }
    }

}
