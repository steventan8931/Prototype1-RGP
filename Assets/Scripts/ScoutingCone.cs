using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutingCone : MonoBehaviour
{
    public AudioSource m_Audio;

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.tag == "Boy")
        {
            _other.GetComponent<Boy>().m_Detected = true;
            m_Audio.Play();
        }
    }

}