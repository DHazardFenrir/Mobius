using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cadenas : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject inundacion;
    [SerializeField] GameObject presaVieja;
    [SerializeField] GameObject nuevaPresa;

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

    }
}
