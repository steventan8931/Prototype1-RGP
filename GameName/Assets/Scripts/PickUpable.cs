﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpable : MonoBehaviour
{
    public GameObject m_Model;

    public bool m_PickedUp = false;

    private void OnTriggerStay(Collider _other)
    {
        if (_other.tag == "Giant")
        {
            Debug.Log("yes");
            if (Input.GetKeyDown(KeyCode.Mouse1) && !m_PickedUp)
            {
                Debug.Log("yes");
                m_Model.transform.position = _other.GetComponent<Giant>().m_Hands.position;
                m_Model.transform.parent = _other.GetComponent<Giant>().m_Hands;

                m_Model.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                m_Model.GetComponent<Rigidbody>().useGravity = false;
                m_PickedUp = true;
            }
        }
    }
}
