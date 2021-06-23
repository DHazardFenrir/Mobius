using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using DialogueSystem.AIDialogue;
using UnityStandardAssets.Characters.FirstPerson;


namespace DialogueSystem.API
{

    public class PlayerConversant : MonoBehaviour
    {
        [SerializeField] string playerName;
        DialogScriptable currentDialogue;
        DialogueNode currentNode = null;
        bool isChoosing = false;
        AIConversant currentConversant = null;
      
        


        public event Action onConversationUpdated;

      
        public bool IsChoosing()
        {
            return isChoosing;
        }

        public string GetText()
        {
            if(currentNode == null)
            {
                return "";
            }
            return currentNode.GetText();
        }

        public void Next()
        {
            
            Debug.Log("Next");
            int numPlayerResponses =   currentDialogue.GetPlayerChildren(currentNode).Count();

            if(numPlayerResponses > 0)
            {
                isChoosing = true;
                TriggerExitAction();
                onConversationUpdated();
                return;
            }

            DialogueNode[] children = currentDialogue.GetAIChildren(currentNode).ToArray();
            int randomIndex = UnityEngine.Random.Range(0, children.Length);
            
            TriggerExitAction();
            currentNode = children[randomIndex];

            TriggerEnterAction();

            onConversationUpdated();

            
        }

        public string GetCurrentConversantName()
        {
            if (isChoosing)
            {
                return playerName;
            }
            else
            {
                return currentConversant.GetName();
            }
        }

        public IEnumerable<DialogueNode> GetChoices()
        {
            return currentDialogue.GetPlayerChildren(currentNode);
        }

        public void SelectChoice(DialogueNode chosenNode)
        {   
            currentNode = chosenNode;
            TriggerEnterAction();
            isChoosing = false;
            Next();
        }
        public bool HasNext()
        {
            
            return currentDialogue.GetAllChildren(currentNode).Count() > 0 ;
        }

        public void StartDialogue(AIConversant newConversant, DialogScriptable newDialogue)
        {
           
            currentConversant = newConversant;
            currentDialogue = newDialogue;
            currentNode = currentDialogue.GetRootNode();
            TriggerEnterAction();
            onConversationUpdated();
          
            GetComponent<RigidbodyFirstPersonController>().enabled = false;
        
        }

        public bool IsActive()
        {
            return currentDialogue != null;
        }

        public void Quit()
        {
            
            currentDialogue = null;
            TriggerExitAction();
            currentNode = null;
            isChoosing = false;
            currentConversant = null;

            onConversationUpdated();
            GetComponent<RigidbodyFirstPersonController>().enabled = true;


        }

        private void TriggerEnterAction()
        {
            if(currentNode != null )
            {
                TriggerAction(currentNode.GetOnEnterAction());
            }
        }

        private void TriggerExitAction()
        {
            if (currentNode != null )
            {
                TriggerAction(currentNode.GetOnExitAction());
            }
        }

        public void TriggerAction(string action)
        {
            if (action == "") return;
            foreach (DialogueTrigger trigger in currentConversant.GetComponents<DialogueTrigger>())
            {
                trigger.Trigger(action);
            }
        }


    }
}
