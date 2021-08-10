using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMoPlayer : MonoBehaviour
{
    [SerializeField] SlowMotionTime slowMotion;

    private void Start()
    {
        slowMotion = FindObjectOfType<SlowMotionTime>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.L))
        {
            SlowTime();
        }

     
    }

    void SlowTime()
    {
        slowMotion.DoSlowMotion();
       
    }
}
