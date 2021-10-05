using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScr : MonoBehaviour
{
    public GameObject WinUi;
    public GameObject Manager;
    public GameObject Exitbutton, MenuButton;

    public void exitgame()
    {
        Application.Quit();
    }

    public void loadmenu()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        if(Manager.GetComponent<GameState>().m_GameWin)
        {
            WinUi.SetActive(true);
        }
    }
}
