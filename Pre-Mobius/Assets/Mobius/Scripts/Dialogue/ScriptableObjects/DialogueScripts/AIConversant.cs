﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DialogueSystem.API;


namespace DialogueSystem.AIDialogue
{
    public class AIConversant : MonoBehaviour, IInteractable
    {
        [SerializeField] DialogScriptable[] dialogue = null;
        [SerializeField] string conversantName;
        PlayerConversant dialogueIsFinished;
        int i;
        [SerializeField]private LightingManager lightManager;

        [SerializeField] bool needEnergy;
        [SerializeField] float energyRequired;
        private Transform playerTransform;


        [SerializeField]TextMeshPro text;

        PlayerEnergy playerE;

        GameManager gm;
        [SerializeField] public Animator anim;

        private void Awake()
        {
            dialogueIsFinished = GameObject.FindObjectOfType<PlayerConversant>();
            lightManager = GameObject.FindObjectOfType<LightingManager>();
            playerE = FindObjectOfType<PlayerEnergy>();
            anim = GetComponent<Animator>();
            playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();

        }

        private void Start()
        {
            if (needEnergy)
            {
                //text = GetComponentInParent<TextMeshPro>();
                text.text = "" + energyRequired;
            }
        }

        public void Interact()
        {
            if(needEnergy)
            {
                if(playerE.energy >= energyRequired)
                {
                    Talk();
                    playerE.EnergyLoose(energyRequired);
                }
            }
            else
            {
                Talk();
            }
        }


        void Talk()
        {


         if (dialogue != null)
         {

             anim.enabled = false;

             transform.LookAt(playerTransform);
            
             StartCoroutine(NextDialogue());
                
         
               
         }
        
        
            

        }

        public string GetName()
        {
            return conversantName;
        }

        IEnumerator NextDialogue()
        {

            for (int i = 0; i <= dialogue.Length-1; i++)
            {
                if (lightManager.timeToGet >= dialogue[i].minTime)
                {
                    
                        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConversant>().StartDialogue(this, dialogue[i]);
                }
                
                if (lightManager.timeToGet >= dialogue[i].maxTime)
                {

                    break;
                }
            }
            
            
          
            
            

          

               









            

            yield return new WaitForSeconds(1f);









        }

        public void CheckTime()
        {
            foreach (var container in dialogue)
            {
                //if (lightManager.timeToGet >= container.minTime)
                //{
                    //StartCoroutine(NextDialogue());
                //}
                
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
            }
        }
    }
}
