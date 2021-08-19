using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cadenas : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject inundacion;
    [SerializeField] GameObject presaVieja;
    [SerializeField] GameObject nuevaPresa;
    [SerializeField] GameObject altar;

     void Start()
    {
        inundacion = GameObject.FindGameObjectWithTag("Inundacion");
        presaVieja = GameObject.FindGameObjectWithTag("PresaRota");
        nuevaPresa = GameObject.FindGameObjectWithTag("PresaCompleta");
    }
    public void Interact()
    {
        DryLake();
    }

    void DryLake()
    {
        Debug.Log("enter");
        inundacion.SetActive(false);
        presaVieja.SetActive(false);
        nuevaPresa.SetActive(true);
        altar.GetComponent<BoxCollider>().enabled = true;
    }
}
