using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueSystem.API;
using UnityStandardAssets.Characters.FirstPerson;

public class GetMouse : MonoBehaviour
{

    RigidbodyFirstPersonController fpmouse;
    public bool conversantIsActive = true;

    private void Awake()
    {
       
        fpmouse = GetComponent<RigidbodyFirstPersonController>();
       
    }

    // Update is called once per frame
    void Update()
    {
       
       
        isTalking(conversantIsActive);
        //Debug.Log(conversantIsActive);
    }

    public void isTalking(bool mouse)
    {
         
        fpmouse.mouseLook.SetCursorLock(mouse);

    }
}
