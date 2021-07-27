using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasVenenoso : MonoBehaviour
{

    float timer;
    [SerializeField] float maxTime;
    LightingManager lM;

    private void Start()
    {
        lM = FindObjectOfType<LightingManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            timer += Time.deltaTime;
            if (timer >= maxTime)
            {
                lM.Loop();
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        timer = 0;
    }



}
