using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private void OnTriggerEnter(Collider _other)
    {
        if (_other.GetComponent<Death>() != null)
        {
            _other.GetComponent<Death>().m_TouchedWater = true;
            Destroy(transform.parent.parent.gameObject);
        }
    }
}
