using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter(Collider _other)
    {
        if (_other.tag == "Boy")
        {
            _other.GetComponent<Boy>().m_KeyCollected = true;
            Destroy(gameObject);
        }
    }
}
