using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightObject : MonoBehaviour
{
    public bool m_Change;
    public Renderer m_Material;
    Color m_Color;

    private void Start()
    {
        m_Material = GetComponent<Renderer>();

        m_Color = m_Material.material.color;
    }

    private void Update()
    {
        if (m_Change)
        {
            m_Material.material.color = new Vector4(0.5f, 0.5f, 0.0f, 1);

        }
        else
        {
            m_Material.material.color = m_Color;
        }
    }
}
