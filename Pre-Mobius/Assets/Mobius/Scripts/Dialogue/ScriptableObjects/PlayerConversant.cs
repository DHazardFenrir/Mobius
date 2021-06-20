using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace DialogueSystem.API
{

    public class PlayerConversant : MonoBehaviour
    {
        DialogScriptable currentDialogue;
        DialogueNode currentNode = null;
        bool isChoosing = false;

        


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
            int numPlayerResponses =   currentDialogue.GetPlayerChildren(currentNode).Count();

            if(numPlayerResponses > 0)
            {
                isChoosing = true;
                onConversationUpdated();
                return;
            }

            DialogueNode[] children = currentDialogue.GetAIChildren(currentNode).ToArray();
            int randomIndex = UnityEngine.Random.Range(0, children.Length);
            currentNode = children[randomIndex];

            onConversationUpdated();
        }
        public IEnumerable<DialogueNode> GetChoices()
        {
            return currentDialogue.GetPlayerChildren(currentNode);
        }

        public void SelectChoice(DialogueNode chosenNode)
        {
            currentNode = chosenNode;
            isChoosing = false;
            Next();
        }
        public bool HasNext()
        {
            
            return currentDialogue.GetAllChildren(currentNode).Count() > 0 ;
        }

        public void StartDialogue(DialogScriptable newDialogue)
        {
            currentDialogue = newDialogue;
            currentNode = currentDialogue.GetRootNode();
            onConversationUpdated();
        }

        public bool IsActive()
        {
            return currentDialogue != null;
        }

        public void Quit()
        {
            currentDialogue = null;
            currentNode = null;
            isChoosing = false;

            onConversationUpdated();
        }


    }
}
