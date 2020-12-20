using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Sprite sprite;
    public string slotname;


    public  void UpdateImage()
    {
        GetComponent<Button>().image.sprite = sprite;
        slotname = sprite.name;
        GetComponentInChildren<TMP_Text>().text = slotname;
        if (sprite != null) GetComponent<Button>().image.color = Color.white;
    } 
    
    public void Equip()
    {
        Managers.Inventory.EquipItem(slotname);
    }

}
