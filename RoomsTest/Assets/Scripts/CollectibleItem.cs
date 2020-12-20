using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public  string itemName;    
    public bool cantake;
    public void onTakeItem()
    {
        if (cantake)
        {
            Managers.Inventory.AddItem(itemName);
            Destroy(this.gameObject);
        }
    }
  
}
