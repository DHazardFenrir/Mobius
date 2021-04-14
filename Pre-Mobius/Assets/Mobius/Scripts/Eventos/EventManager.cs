using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    #region Eventos
    public event Action TreeFallEvent;
    #endregion

    LightingManager lightingManager;


    private void Start()
    {
        lightingManager = FindObjectOfType<LightingManager>();
    }
    private void Update()
    {
        if(lightingManager.timeToGet>=25)
        {
            TreeFallEvent?.Invoke();
        }
    }




}
