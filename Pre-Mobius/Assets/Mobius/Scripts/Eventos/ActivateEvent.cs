using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEvent : Evento
{
    
    [SerializeField] GameObject gameObj;

    protected override void ActiveEvent()
    {

        gameObj.SetActive(true);
        base.ActiveEvent();
        EventManager eventManager = FindObjectOfType<EventManager>();
        eventManager.GetEvents();

    }

}
