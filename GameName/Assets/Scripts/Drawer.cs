using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    public Vector3 m_FinalPosition;
    public float m_LerpSpeed = 5.0f;
    public float m_LerpTimer = 0.0f;

    public bool m_Open;

    private void Update()
    {
        if (m_Open)
        {
            m_LerpTimer += Time.deltaTime * m_LerpSpeed;
            transform.position = Vector3.Lerp(transform.position, m_FinalPosition, m_LerpTimer);
        }
    }

}
