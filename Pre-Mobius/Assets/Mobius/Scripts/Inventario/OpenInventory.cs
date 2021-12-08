using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenInventory : MonoBehaviour
{
    [SerializeField] Image inventoryBackground;
    GameManager gm;
    Inventario inventory;


    public bool isOpen { get; private set; } = false;

    private void Start()
    {
        inventoryBackground.enabled = false;
        gm = FindObjectOfType<GameManager>();
        inventory = FindObjectOfType<Inventario>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I) && !gm.isPaused)
        {
            isOpen = !isOpen;
            inventoryBackground.enabled= isOpen;
            DestroyItemsButtons();
            if(isOpen==true)
            {
            CreateItemsButtons();
            }
            SetSettings();
        }
    }

    [SerializeField] GameObject buttonPrefab;
    void CreateItemsButtons()
    {
        if(inventory.inventory.Count > 0)
        {
            for(int i=0;i<inventory.inventory.Count;i++)
            {
                GameObject itemButton = Instantiate(buttonPrefab);
                itemButton.transform.SetParent(gameObject.transform);
                Debug.Log(inventory.inventory[i].name);
                itemButton.GetComponentInChildren<ButtonSetUp>().item=inventory.inventory[i];
            }
        }
    }

    void DestroyItemsButtons()
    {
        Debug.Log("Esta madre tiene: " + transform.childCount + " hijos");
        if(transform.childCount>0)
        {
        for(int i=transform.childCount-1;i>=0;i--)
        {
            Debug.Log(transform.childCount);
            Destroy(transform.GetChild(i).gameObject);
        }
        }
    }

    void SetSettings()
    {
        if (isOpen)
        {
            Time.timeScale = 0;
            gm.onOtherScreen = true;
            gm.OnUI();
        }
        else
        {
            Time.timeScale = 1;
            gm.onOtherScreen = false;
            gm.OnUI();
        }
    }


}
