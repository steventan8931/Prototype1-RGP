using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public AudioSource m_Audio;
    private void OnTriggerEnter(Collider _other)
    {
        if (_other.tag == "Boy")
            Debug.Log("playing");
            m_Audio.Play();
    }
}
