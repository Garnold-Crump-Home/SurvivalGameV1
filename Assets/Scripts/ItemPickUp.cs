using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Inventory items;

    void PickUp()
    {
        InventroyManager.Instance.Add(items);
        Destroy(gameObject);

    }
    private void OnMouseDown()
    {
        PickUp();
    }
}
