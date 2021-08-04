using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinScr : MonoBehaviour
{
    public GameObject menubutton, quitbutton;
    public void backtoMenu()
    {
        SceneManager.LoadScene(0);

    }
    public void quitgame()
    {
        Application.Quit();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
