using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    public GameObject[] m_Interacables;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            for (int i = 0; i < m_Interacables.Length; i++)
            {
                m_Interacables[i].transform.position = Vector3.zero;
                m_Interacables[i].transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                m_Interacables[i].transform.GetChild(0).transform.position = Vector3.zero;
                m_Interacables[i].transform.GetChild(0).transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            }
        }

    }
}
