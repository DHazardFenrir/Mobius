using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPong : MonoBehaviour
{
    [SerializeField] private GameObject soulGameObject;
    [SerializeField] private float speed;
    [SerializeField] private float height;

  
   

   
 
    void Update() {
       Up();
    }

    void Up()
    {
        //get the objects current position and put it in a variable so we can access it later with less code
        Vector3 pos = soulGameObject.transform.position;
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed);
        //set the object's Y to the new calculated Y
        soulGameObject.transform.position = new Vector3(pos.x, newY, pos.z) * height;

        
    }
}
