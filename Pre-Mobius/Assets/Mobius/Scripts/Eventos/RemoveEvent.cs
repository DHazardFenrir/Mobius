using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveEvent : Evento
{
    [SerializeField] GameObject gameObj;
    protected override void ActiveEvent()
    {
        Destroy(gameObj);
        base.ActiveEvent();
    }

}
