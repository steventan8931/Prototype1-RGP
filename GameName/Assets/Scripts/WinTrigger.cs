using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public AudioSource[] m_AudioSources;

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.tag == "Boy")
        {

            _other.GetComponent<CharacterMotor>().m_Look.m_CursorLocked = false;
            _other.GetComponent<CharacterMotor>().m_Look.LockCursor();
            _other.GetComponent<CharacterMotor>().m_IsControl = false;
            _other.GetComponent<CharacterSwapper>().enabled = false;
            _other.GetComponent<Boy>().m_GameWon = true;
            for (int i = 0; i < m_AudioSources.Length; i++)
            {
                m_AudioSources[i].Stop();
            }

        }
    }

    private void Start()
    {
        m_AudioSources = FindObjectsOfType<AudioSource>();
    }


}
