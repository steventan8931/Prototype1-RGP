using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public Boy m_Boy;

    public bool m_GameWin = false;
    public bool m_BoyDetected = false;
    public bool m_BoyDead= false;

    private void Update()
    {
        m_GameWin = m_Boy.m_GameWon;
        m_BoyDetected = m_Boy.m_Detected;
        m_BoyDead = m_Boy.m_Killed;

        if (m_GameWin)
        {
            //Win the player has reached the game win trigger

        }


        if (m_BoyDetected)
        {
            //Give player feedback to show the player has been detected

        }
        else
        {
            //Turn it off after the player has been respawned
        }

        if (m_BoyDead)
        {
            //Give player feedback to show the player has been killed by death collision in map

        }
        else
        {
            //Turn it off after the player has been respawned
        }
    }
}
