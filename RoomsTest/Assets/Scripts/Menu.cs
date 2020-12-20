using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] bool openmenu =false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) & !openmenu)
        {
            menu.SetActive(true);
            openmenu = true;
        }
        else if  (Input.GetKeyDown(KeyCode.Escape)& openmenu)
        {
            menu.SetActive(false);
            openmenu = false;
        }

    }


    void Start()
    {
        
        menu.SetActive(false);
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
        

    }

}
