using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Evento : MonoBehaviour
{
    [SerializeField] Animator anim;

    public bool active = false;

    public ScriptableEvent eventData;

    public event Action Event;

    void Start()
    {
            //Obtiene el componente del Animator
            if(TryGetComponent(out Animator component))
            {
                anim = component;
            }
            else
            {
                anim = null;
            }       
            //Verifica que contenga datos de evento
            if(eventData==null)
            {
            Debug.Log("El objeto: " + this.gameObject.name + "no contiene scriptable object del evento");
            }
    }

    //Activa el evento (Se llama desde el EventManager)
    public void InvokeEvent()
    {
        Event?.Invoke();
    }

    //Activa la acción del evento
    private void OnEnable()
    {
        Event += ActiveEvent;
    }

    //Lo que hace el evento
    private void ActiveEvent()
    {
        active = true;
        if(anim!=null)
        {
            anim.SetBool("Active", true);
        }
        Debug.Log(eventData.entradaDelDiario);
    }


}
