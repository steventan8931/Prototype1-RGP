using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy : MonoBehaviour
{
    public bool m_KeyCollected = false;

    public bool m_GameWon = false;

    private void Update()
    {
        if (m_GameWon)
        {
            //insert scene transition + win
        }
    }
}
