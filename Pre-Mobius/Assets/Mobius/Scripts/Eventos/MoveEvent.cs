using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEvent : Evento
{
    [SerializeField] GameObject gameObj;
    [SerializeField] Transform spawnPoint;

    protected override void ActiveEvent()
    {
        gameObj.transform.position = spawnPoint.position;
        base.ActiveEvent();
    }

}
