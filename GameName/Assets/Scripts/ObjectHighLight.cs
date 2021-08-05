using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHighLight : MonoBehaviour
{
    public CharacterSwapper m_Swapper;
    public GameObject[] m_GiantItems;
    public GameObject m_BoyItem;

    public Material[] m_GiantHightLightOG;
    public Material m_BoyHightLightOG;

    private void Update()
    {


        if (m_Swapper.m_IsGiant)
        {
            for (int i = 0; i < m_GiantItems.Length; i++)
            {
                m_GiantItems[i].transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
            }
            if (m_BoyItem != null)
            {
                m_BoyItem.transform.GetChild(0).GetComponent<Renderer>().material = m_BoyHightLightOG;
            }
        }
        else
        {
            for (int i = 0; i < m_GiantItems.Length; i++)
            {
                m_GiantItems[i].transform.GetChild(0).GetComponent<Renderer>().material = m_GiantHightLightOG[i];
            }
            if (m_BoyItem != null)
            {
                m_BoyItem.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            }

        }
    }
}
