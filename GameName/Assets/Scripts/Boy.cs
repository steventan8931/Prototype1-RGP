using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy : MonoBehaviour
{
    public bool m_KeyCollected = false;

    public int m_RoomsCleared = 0;

    public bool m_GameWon = false;

    public Transform[] m_Checkpoints;

    private void Update()
    {
        if (m_GameWon)
        {
            //insert scene transition + win
        }
    }
}
