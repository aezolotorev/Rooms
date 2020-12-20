using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


    public class UIManager : MonoBehaviour, IGameManager
    {
        [SerializeField]
        private Canvas canvas;
        [SerializeField]
        private Canvas message;
        [SerializeField]
        private TMP_Text messagetext;
        [SerializeField]
        private GameObject menu;
        [SerializeField] bool openmenu;
        [SerializeField]
        private FirstPersonController fps;
        public ManagerStatus status { get; private set; }
        [SerializeField]
        private KeyCode key = KeyCode.Tab;
        [SerializeField]
        private Slot[] slots;
        public void Startup()
        {
            canvas.enabled = false;
            message.enabled = false;
            slots = canvas.GetComponentsInChildren<Slot>();
            status = ManagerStatus.Started;
            menu.SetActive(false);
            openmenu = false;

        }
        private void Update()
        {
            if (Input.GetKeyDown(key))
            {
                UpdateUI();
                canvas.enabled = !canvas.enabled;
            }
            else if (Input.GetKeyDown(KeyCode.Escape) & !openmenu)
            {
                menu.SetActive(true);
                openmenu = true;
                fps.openmenu = true;
                
            }
            else if (Input.GetKeyDown(KeyCode.Escape) & openmenu)
            {
                menu.SetActive(false);
                openmenu = false;
                fps.openmenu = false;
               
                
            }
        }
        private void UpdateUI()
        {
            List<string> itemList = Managers.Inventory.GetItemList();
            if (itemList.Count == 0)
            {
                return;
            }
            for (int i = 0; i < itemList.Count; i++)
            {
                slots[i].sprite = Resources.Load<Sprite>("Icons/" + itemList[i]);
                slots[i].UpdateImage();
            }
        }

        public void ShowMessageDoor(string keyname)
        {
            messagetext.text = "Door is closed, you need find and equipped key " + keyname;
            //= "Find Key" + keyname;        

            message.enabled = true;

            StartCoroutine(HideMessage());
        }

        IEnumerator HideMessage()
        {
            yield return new WaitForSeconds(1.0f);
            message.enabled = false;
        }

        public void ShowMessageEquip(string keyname)
        {
            messagetext.text = "You equipped " + keyname;
            //= "Find Key" + keyname;        

            message.enabled = true;

            StartCoroutine(HideMessage());
        }
        public void MessageLevel()
        {
            messagetext.text = "Level Complete";
            message.enabled = true;


        }
        public void Exit()
        {
            Application.Quit();
        }

        public void Restart()
        {
            SceneManager.LoadScene(1);

        }

        public void Back()
        {
            menu.SetActive(false);
            openmenu = false;
            fps.openmenu = false;


    }
    }
