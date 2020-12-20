using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reactable : MonoBehaviour
{
    [SerializeField]
    public LightOn lightOn;
    private Outline outline;
    private CollectibleItem collectibleItem;

    private void Start()
    {
        outline = GetComponent<Outline>();
        collectibleItem = GetComponent<CollectibleItem>();
    }
    private void Update()
    {
        if (!lightOn.on)
        {            
            outline.enabled = false;
            collectibleItem.cantake = false;

        }
        if (lightOn.on)
        {
            collectibleItem.cantake = true;
        }
        if (!collectibleItem.cantake)
        {
            outline.enabled = false;
        }

    }
    
 
}
