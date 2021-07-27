using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfrendaHades : MonoBehaviour, IInteractable
{

    [SerializeField] Transform[] spawnFrutas;
    [SerializeField] Items[] frutas;
    [SerializeField] bool[] frutaColocada;
    Inventario inventory;

    private void Start()
    {
        inventory = FindObjectOfType<Inventario>();
    }

    public void Interact()
    {
        ColocarFruta();
    }

    void ColocarFruta()
    {
        for(int i=0;i<spawnFrutas.Length;i++)
        {
            if(inventory.inventory.Contains(frutas[i]) && frutaColocada[i]==false)
            {
                Instantiate(frutas[i].itemPrefab, spawnFrutas[i].position, spawnFrutas[i].rotation);
                frutaColocada[i]= true;
            }
        }
    }




}
