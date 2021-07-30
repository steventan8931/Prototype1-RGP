using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRoom : MonoBehaviour
{
    public Door m_LastDoor;

    public bool m_BoyInCurrentRoom = false;
    public bool m_GiantInCurrentRoom = false;

    private void Update()
    {
        if (m_BoyInCurrentRoom && m_GiantInCurrentRoom)
        {
            m_LastDoor.m_IsOpen = false;
        }
    }
    private void OnTriggerStay(Collider _other)
    {
        if (_other.tag == "Boy")
        {
            m_BoyInCurrentRoom = true;
        }
        if (_other.tag == "Giant")
        {
            m_GiantInCurrentRoom = true;
        }
    }

    private void OnTriggerExit(Collider _other)
    {
        if (_other.tag == "Boy")
        {
            m_BoyInCurrentRoom = false;
        }
        if (_other.tag == "Giant")
        {
            m_GiantInCurrentRoom = false;
        }
    }
}
