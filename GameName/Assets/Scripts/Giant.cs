using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Giant : MonoBehaviour
{
    public bool m_Controllable = true;

    public Transform m_Hands;

    private void Update()
    {
        if (m_Hands.childCount > 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("release");
                m_Hands.GetChild(0).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                m_Hands.GetChild(0).GetComponent<Rigidbody>().useGravity = true;
                m_Hands.GetChild(0).GetChild(0).GetComponent<PickUpable>().m_PickedUp = false;
                m_Hands.GetChild(0).transform.parent = null;
            }
        }

    }
}
