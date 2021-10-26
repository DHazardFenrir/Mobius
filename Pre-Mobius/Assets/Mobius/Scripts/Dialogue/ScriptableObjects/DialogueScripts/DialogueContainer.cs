using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    [CreateAssetMenu(fileName = "New Container", menuName = "NPC Containers", order = 1)] 
    public class DialogueContainer : ScriptableObject
    { 
        [SerializeField] DialogScriptable[] dialogue = null;
        const int DayInMinutes=10;
        [SerializeField, Range(0, DayInMinutes*60)] float maxTimeOfTheDay;
        [SerializeField, Range(0, DayInMinutes*60)] float minTimeOfTheDay;
      
    }

}
