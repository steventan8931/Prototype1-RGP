using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantController : NewCharacterMotor
{
    [Header("Giant Controller Components")]
    public Transform m_Hands;
    public bool m_Controllable = false;

    private void Start()
    {
        m_IsGiant = true;
        m_Controllable = true;
    }

    protected override void Update()
    {
        if (m_IsControl)
        {
            base.Update();
            //Pick Up
            if (m_Hands.childCount > 0)
            {
                m_Animation.SetBool("PushHigh", true);
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Debug.Log("release");
                    m_Hands.GetChild(0).GetChild(0).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    if (m_Hands.GetChild(0).GetChild(0).GetChild(0).GetComponent<PickUpable>().m_RotationLocked)
                    {
                        Debug.Log("redog");
                        m_Hands.GetChild(0).GetChild(0).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                    }
                    m_Hands.GetChild(0).GetChild(0).GetComponent<Rigidbody>().useGravity = true;
                    m_Hands.GetChild(0).GetChild(0).GetChild(0).GetComponent<PickUpable>().m_PickedUp = false;
                    m_Hands.GetChild(0).transform.parent = null;
                }
            }
        }
        else
        {
            m_Animation.SetBool("Walking", false);
        }
    }
}
