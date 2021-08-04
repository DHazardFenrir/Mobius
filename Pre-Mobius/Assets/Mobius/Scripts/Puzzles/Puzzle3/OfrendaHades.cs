using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfrendaHades : MonoBehaviour, IInteractable
{

    [SerializeField] GameObject[] frutas;
    [SerializeField] Items[] frutasItems;
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
        for(int i=0;i<frutas.Length;i++)
        {
            if(inventory.inventory.Contains(frutasItems[i]) && frutaColocada[i]==false)
            {
                frutas[i].SetActive(true);
                frutaColocada[i]= true;
            }
        }
    }

}
