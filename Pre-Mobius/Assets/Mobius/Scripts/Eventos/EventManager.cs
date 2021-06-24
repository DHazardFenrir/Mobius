using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    [SerializeField] Evento[] eventos;

    LightingManager lightingManager;

    [SerializeField] float timer;


    private void Start()
    {
        lightingManager = FindObjectOfType<LightingManager>();
        GetEvents();
    }



    IEnumerator CheckEvent()
    {
        var i = 0;
        while (i<eventos.Length)
        {
            yield return new WaitForSeconds(5);
            //Debug.Log("i = "+i);
            for (int j = 0; j < eventos.Length; j++)
            {
                if (eventos[j].active == false)
                {
                    if (lightingManager.timeToGet >= eventos[j].eventData.horaDeActivacion)
                    {
                        //Debug.Log("El evento se debe activar en: " + eventos[GetEventToActive()].eventData.horaDeActivacion + " y se activó en: " + lightingManager.timeToGet);
                        eventos[j].InvokeEvent();
                        i++;

                    }
                }
            }
        }
        Debug.Log("Ya no hay eventos");
    }

       
    


    //Obtiene los eventos del mapa
    public void GetEvents()
    {
        eventos = FindObjectsOfType<Evento>();
        SortEvents();
    }

    //Ordena los eventos en base al tiempo en que se activan
    void SortEvents()
    {
        for(int i=0;i<eventos.Length;i++)
        {
            for(int j=0;j<eventos.Length-1;j++)
            {
                if (eventos[j].eventData.horaDeActivacion > eventos[j + 1].eventData.horaDeActivacion)
                {
                    var alm = eventos[j + 1];
                    eventos[j + 1] = eventos[j];
                    eventos[j] = alm;
                }
            }
        }
        StartCoroutine(CheckEvent());
    }

    //Obtiene el evento a esperar
    int GetEventToActive()
    {
        var num=0;
        for(int i=0;i<eventos.Length;)
        {
            if(eventos[i].active==false)
            {
                num = i;
                break;
            }
            else
            {
                i++;
            }
        }
        return num;
        
    }

    //Activa el evento
    void ActiveEvent()
    {
        eventos[GetEventToActive()].InvokeEvent();
    }
}
