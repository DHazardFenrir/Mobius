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
    LightingManager lM;

    GameManager gm;

    private void Start()
    {
        lM = FindObjectOfType<LightingManager>();
        inventory = FindObjectOfType<Inventario>();
        gm = FindObjectOfType<GameManager>();
    }

    public void Interact()
    {
        ColocarFruta();
    }


    [SerializeField] AudioSource audioColocarFruta;

    void ColocarFruta()
    {
        for(int i=0;i<frutas.Length;i++)
        {
            if (inventory.inventory.Contains(frutasItems[i]) && frutaColocada[i]==false)
            {
                frutas[i].SetActive(true);
                frutaColocada[i]= true;
                if (audioColocarFruta != null)
                {
                    audioColocarFruta.Play();
                }
                ComprobarFrutero();
            }
            else
            {
                continue;
            }
        }
    }

    [SerializeField] AudioSource audioFinal;

    void ComprobarFrutero()
    {


            if(frutaColocada[0] && frutaColocada[1] && frutaColocada[2] && frutaColocada[3])
            {
                puzzleCompleted = true;
                Debug.Log("Completado puzzle3");
                GetComponent<BoxCollider>().enabled = false;
            if (audioFinal != null)
            {
                audioFinal.Play();
            }
            gm.puzzleFinished(2);
            }
            else
            {
                Debug.Log("Aun te falta morro");
                //lM.Loop();
            }
    }

}
