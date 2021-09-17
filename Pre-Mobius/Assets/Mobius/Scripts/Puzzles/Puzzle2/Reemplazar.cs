using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reemplazar : MonoBehaviour,IInteractable
{
    [SerializeField] GameObject ofrendaReal;
    [SerializeField] GameObject ofrendaFalsa;

    [SerializeField] Items itemRequerido;
    [SerializeField] Items itemADar;

    [SerializeField] AudioSource audio;


    Inventario inventory;

    GameManager gm;

    private void Start()
    {
        inventory = FindObjectOfType<Inventario>();
        gm = FindObjectOfType<GameManager>();
    }

    public void Interact()
    {
        if(inventory.inventory.Contains(itemRequerido))
        {
            inventory.inventory.Add(itemADar);
            Destroy(ofrendaFalsa);
            Debug.Log("Se destruye");
            ofrendaReal.SetActive(true);
            Debug.Log("Se activa");
            if (audio != null)
            {
                audio.Play();
            }
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            Debug.Log("Se desactiva");
            gm.puzzleFinished(1);
            Debug.Log("pal gm");
        }
    }

}
