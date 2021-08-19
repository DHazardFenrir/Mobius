using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DialogueSystem.API;


namespace DialogueSystem.AIDialogue
{
    public class AIConversant : MonoBehaviour, IInteractable
    {
        [SerializeField] DialogScriptable[] dialogue = null;
        [SerializeField] string conversantName;
        PlayerConversant dialogueIsFinished;
        int i;
       
        
        private void Awake()
        {
            dialogueIsFinished = GameObject.FindObjectOfType<PlayerConversant>();
        }

        public void Interact()
        {
            Talk();
        }


        void Talk()
        {


         if (dialogue != null)
         {




                StartCoroutine(NextDialogue());
         
               
         }

            

        }

        public string GetName()
        {
            return conversantName;
        }

        IEnumerator NextDialogue()
        {

            if(i <= dialogue.Length - 1)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConversant>().StartDialogue(this, dialogue[i]);
                i++;
            }
            if(i > dialogue.Length - 1)
            {

                i = dialogue.Length - 1;
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConversant>().StartDialogue(this, dialogue[i]);
               
            }

          

               









            

            yield return new WaitForSeconds(1f);









        }
    }
}
