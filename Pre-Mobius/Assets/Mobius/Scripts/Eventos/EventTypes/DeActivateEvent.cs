using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeActivateEvent : Evento
{

    [SerializeField] GameObject gameObj;
    [SerializeField] GameObject particles;
    [SerializeField] AudioSource audio;


    protected override void ActiveEvent()
    {

        gameObj.SetActive(false);

        if (audio != null)
        {
            audio.Play();
        }

        if (particles != null)
        {
            GameObject particulas = Instantiate(particles, gameObj.transform.position, gameObj.transform.rotation);
        Destroy(particulas, 1.5f);
        }
        base.ActiveEvent();
        EventManager eventManager = FindObjectOfType<EventManager>();
        eventManager.GetEvents();

    }

}
