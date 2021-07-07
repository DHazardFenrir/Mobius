using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceEvent : Evento
{
    [SerializeField] GameObject prefab;
    [SerializeField] Transform spawnPoint;

    protected override void ActiveEvent()
    {
        GameObject spawnedObject = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        base.ActiveEvent();
        EventManager eventManager = FindObjectOfType<EventManager>();
        eventManager.GetEvents();
    }

}