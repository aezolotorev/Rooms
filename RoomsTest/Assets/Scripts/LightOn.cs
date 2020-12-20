using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOn : MonoBehaviour
{
    public Light lightSecondRoom;
    [SerializeField]
    private KeyCode key = KeyCode.F;    
    public bool on=false;
    public Collider triger;

    private void Start()
    {
        lightSecondRoom.enabled = false;
    }  


    private void OnTriggerStay(Collider other)
    {  
            if (other.CompareTag("Player") && Input.GetKeyDown(key))
            {           
            lightSecondRoom.enabled = !lightSecondRoom.enabled;
            on = !on;
            Managers.Player.SwitchLight();
            }
  
    }


}
