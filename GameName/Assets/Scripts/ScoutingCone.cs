using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutingCone : MonoBehaviour
{
    private void OnTriggerEnter(Collider _other)
    {
        if (_other.tag == "Boy")
        {
            _other.GetComponent<Boy>().m_Detected = true;
        }
    }

}
