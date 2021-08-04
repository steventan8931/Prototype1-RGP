using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider _other)
    {
        if (_other.tag == "Boy")
        {

            _other.GetComponent<CharacterMotor>().m_Look.m_CursorLocked = false;
            _other.GetComponent<CharacterMotor>().m_Look.LockCursor();
            _other.GetComponent<CharacterMotor>().enabled = false;
            _other.GetComponent<CharacterSwapper>().enabled = false;
            _other.GetComponent<Boy>().m_GameWon = true;

        }
    }

    private void OnTriggerStay(Collider _other)
    {
        _other.transform.GetChild(1).GetComponent<MouseLook>().ManagedUpdate();
    }
}
