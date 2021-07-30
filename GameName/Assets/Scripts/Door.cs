using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool m_IsOpen = false;

    public int m_KeysCollected = 0;

    public Transform m_Pivot;

    public float m_DoorRotateTimer = 0.0f;

    private void Update()
    {
        if (m_IsOpen && m_DoorRotateTimer <= 1.0f)
        {
            m_DoorRotateTimer += Time.deltaTime;
            float YRotation = Mathf.Lerp(0.0f, 90.0f, m_DoorRotateTimer);
            m_Pivot.rotation = Quaternion.Euler(0.0f, YRotation, 0.0f);
        }

        if (!m_IsOpen && m_DoorRotateTimer >= 0.0f)
        {
            m_DoorRotateTimer -= Time.deltaTime;
            float YRotation = Mathf.Lerp(0.0f, 90.0f, m_DoorRotateTimer);
            m_Pivot.rotation = Quaternion.Euler(0.0f, YRotation, 0.0f);
        }
    }
}
