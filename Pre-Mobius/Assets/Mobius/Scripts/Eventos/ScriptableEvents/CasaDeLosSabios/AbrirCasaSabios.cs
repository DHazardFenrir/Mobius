using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirCasaSabios : MonoBehaviour
{
    [SerializeField] EventManager eventManager;

    private void Start()
    {
        eventManager = FindObjectOfType<EventManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Alma"))
        {
            Debug.Log("ChocoConLaPuerta");
            Animator anim = GetComponent<Animator>();
            anim.SetBool("Active", true);
            eventManager.GetEvents();
            Destroy(other.gameObject);
        }
    }

    

}
