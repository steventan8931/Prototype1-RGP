using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHighlight : MonoBehaviour
{
    public Giant m_Giant;

    public Material m_HighLight;
    public Material m_Default;

    private void Update()
    {
        if (m_Giant.GetComponent<CharacterSwapper>().m_IsGiant)
        {
            Debug.Log("giant");
            GetComponent<Renderer>().material = m_HighLight;
        }
        else
        {
            Debug.Log("boyt");
            GetComponent<Renderer>().material = m_Default;
        }
    }
}
