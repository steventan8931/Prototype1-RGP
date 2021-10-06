using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Camera m_AttachedCamera;

    public bool m_CursorLocked = true;

    public void Awake()
    {
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
    }
}
