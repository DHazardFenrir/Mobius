using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GasVenenoso : MonoBehaviour
{

    float timer;
    [SerializeField] float maxTime;
    LightingManager lM;
    Inventario inventory;
    [SerializeField] Items item;
    [SerializeField]CanvasGroup damageCanvas;

    private void Start()
    {
        lM = FindObjectOfType<LightingManager>();
        inventory = FindObjectOfType<Inventario>();
        damageCanvas = GameObject.Find("Damage").GetComponent<CanvasGroup>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("El player entro al gas");
            if(item==null || !inventory.inventory.Contains(item))
            {
                Debug.Log("Aggghh me estoy ahogando alv");
                timer += Time.deltaTime;
                damageCanvas.DOFade(1f, maxTime);
                if (timer >= maxTime)
                    {
                        lM.StartLoopFadeForOthers();
                    }
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        timer = 0;
        damageCanvas.DOFade(0f, maxTime);
    }



}
