using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCanvas : MonoBehaviour
{
     public  void StartButton()
    {
        SceneManager.LoadScene("Scene2");
    }
    public void ExitButton()
    {
        Application.Quit();
    }

}
