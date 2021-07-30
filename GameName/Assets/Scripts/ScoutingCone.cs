using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutingCone : MonoBehaviour
{
    private void OnTriggerEnter(Collider _other)
    {
        if (_other.tag == "Boy")
        {
            _other.GetComponent<CharacterController>().enabled = false;
            _other.transform.position = _other.GetComponent<Boy>().m_Checkpoints[_other.GetComponent<Boy>().m_RoomsCleared].position;
            _other.GetComponent<CharacterController>().enabled = true;
        }
    }

}
