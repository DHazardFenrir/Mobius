using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueSystem.API;


namespace DialogueSystem.AIDialogue
{
    public class AIConversant : MonoBehaviour, IInteractable
    {
        [SerializeField] DialogScriptable dialogue = null;
        
        public void Interact()
        {
            Talk();
        }


        void Talk()
        {


         if (dialogue != null)
         {
          GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConversant>().StartDialogue(dialogue);
         }




        }
    }
}
