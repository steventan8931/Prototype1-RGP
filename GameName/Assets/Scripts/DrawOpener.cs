using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawOpener : MonoBehaviour
{
    public Drawer m_Drawer;
    public AudioSource m_Audio;

    private void OnTriggerStay(Collider _other)
    {
        if (_other.tag == "Giant")
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Debug.Log("enter");
                m_Drawer.m_Open = true;
                m_Audio.Play();
            }
        }
    }
}
