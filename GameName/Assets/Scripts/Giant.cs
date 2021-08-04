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
        //Pick Up
        if (m_Hands.childCount > 0)
        {
            GetComponent<CharacterMotor>().m_Animation.SetBool("PushHigh", true);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                m_Hands.GetChild(0).GetChild(0).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                if (m_Hands.GetChild(0).GetChild(0).GetChild(0).GetComponent<PickUpable>().m_RotationLocked)
                {
                    m_Hands.GetChild(0).GetChild(0).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                }
                m_Hands.GetChild(0).GetChild(0).GetComponent<Rigidbody>().useGravity = true;
                m_Hands.GetChild(0).GetChild(0).GetChild(0).GetComponent<PickUpable>().m_PickedUp = false;
                m_Hands.GetChild(0).transform.parent = null;
            }
        }
    }
}
