using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSetUp : MonoBehaviour
{
    Inventario inventory;
    [SerializeField] Items item;

    [SerializeField] GameObject inspectCanvas;
    [SerializeField] GameObject inventoryCanvas;
    [SerializeField] GameObject inspectCamera;

    [SerializeField] Transform itemPosition;

    [SerializeField] Text descriptionText;

    OpenInventory openInventory;

    private void Start()
    {
        inventory = FindObjectOfType<Inventario>();
        openInventory = FindObjectOfType<OpenInventory>();

    }

    private void Update()
    {
        if (openInventory.isOpen)
        {
            SetButtons();
        }
        Instanciar();
    }

    void SetButtons()
    {
        if (inventory.inventory.Contains(item))
        {
            GetComponent<Image>().sprite = item.itemSprite;
            GetComponent<Button>().interactable = true;
        }
    }

    
    public void InspecItem()
    {
        inspectCanvas.SetActive(true);
        inspectCamera.SetActive(true);
        inventoryCanvas.SetActive(false);
        GameObject itemToInspect = Instantiate(item.itemPrefab, itemPosition.position, itemPosition.rotation);
        Debug.Log(itemToInspect.name);
        descriptionText.text = item.itemDescription;
    }

    public void Instanciar()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {

            GameObject itemToInspect = Instantiate(item.itemPrefab, itemPosition.position, itemPosition.rotation);

        }
    }

    public void Back()
    {
        descriptionText.text = " ";
        inspectCanvas.SetActive(false);
        inspectCamera.SetActive(false);
        inventoryCanvas.SetActive(true);       
    }


}
