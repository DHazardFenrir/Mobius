using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvent : Evento
{
    protected override void ActiveEvent()
    {

        var anim = GetComponent<Animator>();
        anim.SetBool("Active", true);
        base.ActiveEvent();
        EventManager eventManager = FindObjectOfType<EventManager>();
        eventManager.GetEvents();

    }

}