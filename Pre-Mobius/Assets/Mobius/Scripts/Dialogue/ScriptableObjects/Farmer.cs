using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Farmer : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject imageBox = default;
    [SerializeField] TMP_Text textLabel;
    [SerializeField] DialogScriptable dialog;
    [SerializeField] float timeWait;
  
    public void Interact()
    {
        imageBox.SetActive(true);
        StartCoroutine(waitInterDialogues());
       

        

     
        
      
    }

    IEnumerator waitInterDialogues()
    {
        for (int i = 0; i < dialog.messages.Length; i++)
        {
          
            textLabel.text = dialog.messages[i].text;

           
           yield return new WaitForSeconds(timeWait);

           
        }

        StartCoroutine(DissapearBox());


    }

    IEnumerator DissapearBox()
    {
        imageBox.SetActive(false);
        yield return new WaitForSeconds(8f);
    }

}

