using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    [CreateAssetMenu(fileName = "New Container", menuName = "NPC Containers", order = 1)] 
    public class DialogueContainer : ScriptableObject
    { 
        [SerializeField] public DialogScriptable[] dialogue = null;
        
        [Range(0,600)] public float maxTime;
        [Range(0,600)] public float minTime;
      
    }

}
