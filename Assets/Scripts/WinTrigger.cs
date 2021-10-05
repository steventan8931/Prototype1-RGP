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
            m_AudioSources = FindObjectsOfType<AudioSource>();
            for (int i = 0; i < m_AudioSources.Length; i++)
            {
                m_AudioSources[i].Stop();
            }
            _other.GetComponent<CharacterMotor>().m_Look.m_CursorLocked = false;
            _other.GetComponent<CharacterMotor>().m_Look.LockCursor();
            _other.GetComponent<CharacterMotor>().enabled = false;
            _other.GetComponent<CharacterSwapper>().enabled = false;
            _other.GetComponent<Boy>().m_GameWon = true;


        }
    }




}
