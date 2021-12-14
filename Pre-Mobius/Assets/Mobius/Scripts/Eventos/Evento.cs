using System.Collections;
using System.Collections.Generic;
using System;
using DG.Tweening;
using UnityEngine;


[ExecuteInEditMode]
public class Evento : MonoBehaviour
{
    public bool active = false;
    public ScriptableEvent eventData;
    public event Action onExecuteEvent;
    PlayerDiary diary;

    void Start()
    {
            //Verifica que contenga datos de evento
            if(eventData==null)
            {
            Debug.Log("El objeto: " + this.gameObject.name + "no contiene scriptable object del evento");
            diary = null;         

            }

            
        diary = FindObjectOfType<PlayerDiary>();

    }

    //Activa el evento (Se llama desde el EventManager)
    public void InvokeEvent()
    {
        onExecuteEvent?.Invoke();
    }

    //Activa la acción del evento
    private void OnEnable()
    {
        onExecuteEvent += ActiveEvent;
    }

    private void OnDisable()
    {
        onExecuteEvent -= ActiveEvent;
    }

    protected virtual void ActiveEvent()
    {
        DiaryEntry();
        active = true;
    }


     void DiaryEntry()
    {
        diary.textEvent.text = eventData.entradaDelDiario;

        Debug.Log(eventData.entradaDelDiario);
    }
  
}
