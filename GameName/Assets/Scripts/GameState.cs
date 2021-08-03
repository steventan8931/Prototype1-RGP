using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public Boy m_Boy;

    public bool m_GameWin;
    public bool m_BoyDetected;

    private void Update()
    {
        m_GameWin = m_Boy.m_GameWon;
        m_BoyDetected = m_Boy.m_Detected;

        if (m_GameWin)
        {
            //Win the player has reached the game win trigger

        }

        
        if(m_BoyDetected)
        {
            //Give player feedback to show the player has been detected

        }
        else
        {
            //Turn it off after the player has been respawned
        }
    }
}
