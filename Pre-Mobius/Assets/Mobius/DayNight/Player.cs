using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    LightingManager lManager;
    void Start()
    {
        lManager = FindObjectOfType<LightingManager>();
   

    }
   public void DontDestroyPlayer()
    {
        Debug.Log(lManager.player.name + "3");
        if (lManager.player != this.gameObject)
        {
            lManager.GetPlayer(this.gameObject);
            Debug.Log(lManager.player.name + "4");
        }
    }

}

