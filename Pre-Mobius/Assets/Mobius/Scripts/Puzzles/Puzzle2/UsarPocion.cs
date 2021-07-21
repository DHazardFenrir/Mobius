using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsarPocion : MonoBehaviour
{
    [SerializeField] MeshRenderer[] runas;

    Items pocionItem;
    public bool efectoActivo { get; private set; } = false;
    [SerializeField] float duracionPocion;

    private LightingManager lM;

    
    [SerializeField,Range(0,600)] float horaRequerida;

    Inventario inventory;

    private void Start()
    {
        lM = FindObjectOfType<LightingManager>();
        inventory = FindObjectOfType<Inventario>();
        
    }

    void ActivarEfecto()
    {
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
    }

    IEnumerator duracion()
    {
        yield return new WaitForSeconds(duracionPocion);
        DesactivarEfecto();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(lM.timeToGet >= horaRequerida && inventory.inventory.Contains(pocionItem) && efectoActivo==false)
            {
                StartCoroutine(duracion());
                ActivarEfecto();
            }
        }
    }

}
