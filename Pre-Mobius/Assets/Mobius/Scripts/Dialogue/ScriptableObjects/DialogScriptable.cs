using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[CreateAssetMenu(fileName = "NPCDialog", menuName = "NPC Dialogues", order = 1)]

[System.Serializable]
public class DialogScriptable : ScriptableObject
{

    public int npcID;
    public string npcName;
    public Message[] messages;





}

[System.Serializable]
public class Message
{
    public string text;
   
}





