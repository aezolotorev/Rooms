using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IGameManager
{
    public  ManagerStatus status { get; private set; }
    public Transform fpscamera;
    private Shader Outline;
    private Shader Base;
    private RaycastHit Hit;
    [SerializeField]
    private GameObject TempGO;
    private KeyCode key = KeyCode.F;
    [SerializeField]
    private Light light;
    [SerializeField]
    private bool isLightOn;
    public void Startup()
    {
        fpscamera = FindObjectOfType<Camera>().transform;
        isLightOn = false;
        status = ManagerStatus.Started;
    } 
     
    
    void Update()
    {
        OutLineInObjects();
        if (Input.GetKeyDown(key) && TempGO != null)
        {
            if(TempGO.name!="Switcher")
            TempGO.GetComponent<CollectibleItem>().onTakeItem();      
                        
        }
    }

    private void OutLineInObjects()
    {
        if (Physics.Raycast(fpscamera.position, fpscamera.forward, out Hit, 4.5f))
        {
            Collider target = Hit.collider;
            if (target.tag == "Reactable")
            {
                if (!TempGO)
                {
                    TempGO = target.gameObject;
                }
                Select(true);
                if (TempGO.GetInstanceID() != target.gameObject.GetInstanceID())
                {
                    Select(false);
                    TempGO = null;
                }
            }
            else
            {
                Select(false);
            }
        }
        else
        {
            Select(false);
        }
    }
    private void Select(bool On)
    {
        if (TempGO)
        {
            if (On)
            {
                if (TempGO.GetComponent<Reactable>()!=null && TempGO.GetComponent<Reactable>().lightOn.on != true) return;
                TempGO.GetComponent<Outline>().enabled = true;
            }
            else
            {
                TempGO.GetComponent<Outline>().enabled = false;
            }
        }
    }
    public bool SwitchLight()
    {
        light.enabled = (light.enabled == false) ? true : false;
        return isLightOn=!isLightOn;
    }
}
