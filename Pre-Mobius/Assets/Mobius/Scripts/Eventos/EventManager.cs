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

    private void Update()
    {
        //Activa el evento si se llega a la hora especifica
        timer += Time.deltaTime;
        if(timer>=1)
        {
            if(eventos[GetEventToActive()].active==false)
            {
                if(lightingManager.timeToGet >= eventos[GetEventToActive()].eventData.horaDeActivacion)
                {
                //    Debug.Log(eventos[GetEventToActive()].eventData.horaDeActivacion);
                //    Debug.Log(lightingManager.timeToGet);
                    ActiveEvent();
                    timer = 0;
                }
                else
                {
                    timer = 0;
                }
            }
            else
            {
                timer = 0;
            }
        }
        //Comprobar orden de eventos
        if(Input.GetKeyDown(KeyCode.M))
        {
            for (int i = 0; i < eventos.Length; i++)
            {
                Debug.Log(eventos[i].gameObject.name+ ": "+eventos[i].eventData.name);
            }
        }
    }

    //Obtiene los eventos del mapa
    void GetEvents()
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
