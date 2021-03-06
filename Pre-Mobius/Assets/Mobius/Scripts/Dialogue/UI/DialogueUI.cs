using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueSystem.API;
using TMPro;
using UnityEngine.UI;
namespace DialogueSystem.UI
{
    public class DialogueUI : MonoBehaviour
    {
        PlayerConversant playerConversant;
        [SerializeField] TextMeshProUGUI AIText;
        [SerializeField] Button nextButton;

        [SerializeField] Transform choiceRoot;

        [SerializeField] GameObject choicePrefab;
        [SerializeField] GameObject AIResponse;

        [SerializeField] Button quitButton;

        [SerializeField] TextMeshProUGUI conversantName;

        // Start is called before the first frame update
        void Start()
        {
           playerConversant =   GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConversant>();
            playerConversant.onConversationUpdated += UpdateUI;
            nextButton.onClick.AddListener(() => playerConversant.Next());
            quitButton.onClick.AddListener(() => playerConversant.Quit());
            
            
            UpdateUI();

        }

        private void OnDestroy()
        {
            playerConversant.onConversationUpdated -= UpdateUI;

        }



        void UpdateUI()
        {
            gameObject.SetActive(playerConversant.IsActive());

            if (!playerConversant.IsActive())
            {
                return;
            }
            conversantName.text = playerConversant.GetCurrentConversantName();
            AIResponse.SetActive(!playerConversant.IsChoosing());
            choiceRoot.gameObject.SetActive(playerConversant.IsChoosing());

            if (playerConversant.IsChoosing())
            {
                BuildChoiceList();
            }
            else
            {
                AIText.text = playerConversant.GetText();
              
                nextButton.gameObject.SetActive(playerConversant.HasNext());
                Debug.Log("Conversant has Next" + playerConversant.HasNext());

            }
            
        }

        private void BuildChoiceList()
        {
            foreach (Transform item in choiceRoot)
            {
                Destroy(item.gameObject);
            }

            foreach (DialogueNode choice in playerConversant.GetChoices())
            {
                GameObject choiceInstance = Instantiate(choicePrefab, choiceRoot);
                var textComp = choiceInstance.GetComponentInChildren<TextMeshProUGUI>();
                textComp.text = choice.GetText();
                Button button = choiceInstance.GetComponentInChildren<Button>();
                button.onClick.AddListener(() =>
                {
                    playerConversant.SelectChoice(choice);
                   

                });
            }
        }
    }
}
