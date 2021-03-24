using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "Inventario/NuevoItem", order = 1)]
public class Items : ScriptableObject
{
    public Sprite itemSprite;
    public GameObject itemPrefab;
    public string itemDescription;
}
