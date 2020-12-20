using UnityEngine;
using System.Collections;

public class DoorTwoSide : MonoBehaviour
{
    public bool startopening = false;
    public bool open = false;

    private bool openedCompletly;
    private bool openedFront = false;
    private bool openedBack = false;

    public KeyCode key = KeyCode.F;
    public float doorCloseAngle = 0f;
    public float doorOpenAngle = 90f;

    public bool front = false;
    public bool back = false;

    public float forceOpen;



    private AudioSource audioSource;
    public AudioClip[] openingsound;
    [SerializeField]
    private string nameKey;
    [SerializeField]
    private bool requireKey;
    public int i = 0;
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeDoorState()
    {
        if (requireKey)
        {
            if (Managers.Inventory.equippedItem == nameKey && !open)
            {
                requireKey = false;               
            }

            if (!open && requireKey && Managers.Inventory.equippedItem != nameKey)
            {
                Debug.Log("Закрыто");
                audioSource.PlayOneShot(openingsound[2]);
                Managers.UIMan.ShowMessageDoor(nameKey);
            }
        }
        if (!requireKey)
        {
            open = !open;
            if (audioSource != null)
            {
                i = (i == 1) ? 0 : 1;
                audioSource.PlayOneShot(openingsound[i]);
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(key) && ((front || back) == true))
        {
            ChangeDoorState();
        }

        if (open)
        {
            if (front && openedCompletly == false && openedBack== false)
            {
                Quaternion targetRotationOpen = Quaternion.Euler(0, -doorOpenAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationOpen, forceOpen * Time.deltaTime);
                openedFront = true;
                openedBack = false;
                if (transform.rotation == targetRotationOpen)
                {
                    openedCompletly = true;
                    
                }
                
            }
            else if (back && openedCompletly == false && openedFront==false)
            {
                Quaternion targetRotationOpen = Quaternion.Euler(0, doorOpenAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationOpen, forceOpen * Time.deltaTime);
                openedFront = false;
                openedBack = true;
                if (transform.rotation == targetRotationOpen)
                {
                    openedCompletly = true;
                }    

            }
        }
        else
        {
            Quaternion targetRotationClosed = Quaternion.Euler(0, doorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationClosed, forceOpen * Time.deltaTime);
            openedCompletly = false;
            openedFront = false;
            openedBack = false;
        }

           
    }
}