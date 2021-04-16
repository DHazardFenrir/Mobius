using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMoPlayer : MonoBehaviour
{
    [SerializeField] SlowMotionTime slowMotion;
    
    

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.E))
        SlowTime();
    }

    void SlowTime()
    {
        slowMotion.DoSlowMotion();
    }
}
