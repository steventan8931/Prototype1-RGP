using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giant : MonoBehaviour
{
    public bool m_Controllable = true;

    public float m_AwakeTimer = 0.0f;
    public float m_WakeUpTime = 10.0f;

    public Transform m_Hands;

    private void Update()
    {
        m_AwakeTimer += Time.deltaTime;

        if (m_AwakeTimer > m_WakeUpTime)
        {
            m_Controllable = false;
        }

        if (m_Hands.childCount > 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("release");
                m_Hands.GetChild(0).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                m_Hands.GetChild(0).GetComponent<Rigidbody>().useGravity = true;
                m_Hands.GetChild(0).transform.parent = null;
                m_Hands.GetChild(0).GetChild(0).GetComponent<PickUpable>().m_PickedUp = false;
            }
        }

    }
}
