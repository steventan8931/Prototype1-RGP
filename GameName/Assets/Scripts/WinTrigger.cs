using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider _other)
    {
        if (_other.tag == "Boy")
        {
            _other.GetComponent<Boy>().m_GameWon = true;
        }
    }
}
