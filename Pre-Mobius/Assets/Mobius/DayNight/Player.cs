using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    LightingManager lManager;
    void Start()
    {
        lManager = FindObjectOfType<LightingManager>();
        DestroyImpostor();

    }
   public void DestroyImpostor()
    {
        if (lManager.player != this.gameObject)
        {
            Destroy(this.gameObject);
        }
    }

}

