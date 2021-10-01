using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSetUp : MonoBehaviour
{
    Inventario inventory;
    public Items item;

    [SerializeField] GameObject inspectCanvas;
    [SerializeField] GameObject inventoryCanvas;
    [SerializeField] GameObject inspectCamera;

    [SerializeField] Transform itemPosition;
    GameManager gm;

    private void Start()
    {
        sprite = GetComponent<Image>();
        gm = FindObjectOfType<GameManager>();
        inspectCanvas = GameObject.Find("InspectCanvas").transform.GetChild(0).gameObject;
        inventoryCanvas = GameObject.Find("InventoryBackground");
        inventory = FindObjectOfType<Inventario>();
        inspectCamera = GameObject.Find("InspectCamera");
        itemPosition = GameObject.Find("InspectSpawn").GetComponent<Transform>();
        SetButtons();
    }


    [SerializeField] Image sprite;
    public void SetButtons()
    {
            sprite.sprite = item.itemSprite;
            GetComponent<Button>().interactable = true;
    }


    public void InspecItem()
    {
        DestroyInspectItem();
        inspectCanvas.SetActive(true);
        inspectCamera.GetComponent<Camera>().enabled = true;
        inventoryCanvas.SetActive(false);
        GameObject itemToInspect = Instantiate(item.itemPrefab, itemPosition.position, itemPosition.rotation);
        gm.itemToDestroy = itemToInspect;
        Debug.Log(gm.itemToDestroy.name);
        gm.descriptionText.text = item.itemDescription;
    }

    public void DestroyInspectItem()
    {
        gm.DestroyItem();
    }


}
