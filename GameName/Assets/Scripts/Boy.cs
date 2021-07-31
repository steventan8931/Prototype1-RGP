using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy : MonoBehaviour
{
    public bool m_KeyCollected = false;

    public int m_RoomsCleared = 0;

    public bool m_GameWon = false;

    public Transform[] m_Checkpoints;

    public bool m_Detected = false;
    public float m_RespawnDelay = 0.0f;

    private void Update()
    {
        if (m_GameWon)
        {
            //insert scene transition + win
        }

        if (m_Detected)
        {
            m_RespawnDelay += Time.deltaTime;
            if (m_RespawnDelay > 0.2f)
            {
                GetComponent<CharacterController>().enabled = false;
                transform.position = m_Checkpoints[m_RoomsCleared].position;
                GetComponent<CharacterController>().enabled = true;
                m_Detected = false;
            }
        }
    }


}
