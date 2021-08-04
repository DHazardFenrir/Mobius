using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfrendaHades : MonoBehaviour, IInteractable
{

    [SerializeField] GameObject[] frutas;
    [SerializeField] Items[] frutasItems;
    [SerializeField] bool[] frutaColocada;
    bool puzzleCompleted;
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
            Debug.Log("1");
            if (inventory.inventory.Contains(frutasItems[i]) && frutaColocada[i]==false)
            {
                Debug.Log("2");
                frutas[i].SetActive(true);
                Debug.Log("3");
                frutaColocada[i]= true;
                Debug.Log("4");
                ComprobarFrutero();
            }
            else
            {
                continue;
            }           
        }
    }

    void ComprobarFrutero()
    {
        for(int i=0;i<frutaColocada.Length;)
        {
            if(frutaColocada[i]==true)
            {
                i++;
            }
            else
            {
                //aqui te mueres
                break;
            }

            if(i<frutaColocada.Length)
            {
                puzzleCompleted = true;
                Debug.Log("Completado");
                GetComponent<BoxCollider>().enabled = false;
            }
            else
            {
                //aqui te mueres tambien
                break;
            }
        }

    }

}
