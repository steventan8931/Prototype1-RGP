using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public bool m_TouchedWater = false;

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.tag == "Boy")
        {
            _other.GetComponent<Boy>().m_Killed = true;
        }
    }
}
