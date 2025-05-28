using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventroyManager : MonoBehaviour
{
    public static InventroyManager Instance;
    public List<AllItem> allItems = new List<AllItem>();
    private void Awake()
    {
        Instance = this;
    }
   public void Add(AllItem item)
    {
        allItems.Add(item);
    }
    public void Remove(AllItem item)
    {
        allItems.Remove(item);
    }
}
