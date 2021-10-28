using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColocarOfrenda : MonoBehaviour, IInteractable
{
    [SerializeField] Items itemRequerido;
    [SerializeField] GameObject hozDemeter;
    [SerializeField] Transform ofrendaSpawn;
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
            Instantiate(hozDemeter, ofrendaSpawn.position, ofrendaSpawn.rotation);
            gm.puzzleFinished(0);
        }
    }

}
