using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeActivateEvent : Evento
{

    [SerializeField] GameObject gameObj;

    protected override void ActiveEvent()
    {

        gameObj.SetActive(false);
        base.ActiveEvent();

    }

}
