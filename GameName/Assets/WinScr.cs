using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScr : MonoBehaviour
{
    public GameObject WinUi;
    public GameObject Manager;

    
    void Update()
    {
        if(Manager.GetComponent<GameState>().m_GameWin)
        {
            WinUi.SetActive(true);
        }
    }
}
