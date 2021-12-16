using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FollowWorld : MonoBehaviour
{
   [Header("Tweaks")] [SerializeField] public Transform lookAt;
   [SerializeField] public Vector3 offset;

   [Header("Cam")] private Camera cam;

   private void Awake()
   {

      cam = Camera.main;
      lookAt = GetComponent<Transform>();
   }

   private void Update()
   {
       Vector3 pos = cam.WorldToScreenPoint((lookAt.position + offset));

       if (transform.position != pos)
       {
           transform.position = pos;
       }
   }
}
