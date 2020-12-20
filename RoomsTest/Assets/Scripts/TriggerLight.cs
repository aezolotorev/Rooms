using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLight : MonoBehaviour
{
    [SerializeField]    
    private LightOn lightOn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&& !lightOn.on)
        {
            Managers.Player.SwitchLight();            
        }
    }
    private void OnTriggerStay(Collider other)
    {

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") &&!lightOn.on)
        {
            Managers.Player.SwitchLight();
        }
        if (other.CompareTag("Player") && lightOn.on)
        {
            return;
        }

    }

}
