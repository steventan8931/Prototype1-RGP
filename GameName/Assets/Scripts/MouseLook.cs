using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Camera m_AttachedCamera;

    public float m_Spin = 0.0f;
    public float m_Tilt = 0.0f;

    public Vector2 m_TiltExtents = new Vector2(-85.0f, 85.0f);

    public float m_Sensitivty = 2.0f;

    public bool m_CursorLocked = true;

    public void Awake()
    {
        m_AttachedCamera.enabled = false;
        m_Spin = transform.eulerAngles.y;
        m_Tilt = transform.eulerAngles.x;
        LockCursor();
    }

    public void LockCursor()
    {
        Cursor.visible = !m_CursorLocked;
        Cursor.lockState = m_CursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
    }

    public void ManagedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            m_CursorLocked = !m_CursorLocked;
            LockCursor();
        }

        float x = Input.GetAxisRaw("Mouse X");
        float y = Input.GetAxisRaw("Mouse Y");

        m_Spin += x * m_Sensitivty;
        m_Tilt -= y * m_Sensitivty;

        m_Tilt = Mathf.Clamp(m_Tilt, m_TiltExtents.x, m_TiltExtents.y);

        transform.localEulerAngles = new Vector3(m_Tilt, m_Spin, 0.0f);
    }
}
