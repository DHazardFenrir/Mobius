using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceEvent : Evento
{
    [SerializeField] GameObject prefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject particles;
    [SerializeField] AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    protected override void ActiveEvent()
    {
        GameObject spawnedObject = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        if (audio != null)
        {
            audio.Play();
        }
        if (particles != null)
        { 
        GameObject particulas = Instantiate(particles, spawnPoint.transform.position, spawnPoint.transform.rotation);
        Destroy(particulas, 1.5f);
        }
        base.ActiveEvent();
        EventManager eventManager = FindObjectOfType<EventManager>();
        eventManager.GetEvents();
    }

}