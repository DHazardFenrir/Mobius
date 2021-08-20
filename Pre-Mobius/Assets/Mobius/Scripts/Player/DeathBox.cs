using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    LightingManager lM;

    // Start is called before the first frame update
    void Start()
    {
        lM = FindObjectOfType<LightingManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            lM.StartLoopFadeForOthers();
        }
    }
}
