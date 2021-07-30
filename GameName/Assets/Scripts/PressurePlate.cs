using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Door m_DoorComponent;

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.tag == "Boy")
        {
            if (_other.GetComponent<Boy>().m_KeyCollected)
            {
                m_DoorComponent.m_IsOpen = true;
                _other.GetComponent<Boy>().m_KeyCollected = false;
            }
        }

    }
}
