using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwapperEffect : MonoBehaviour
{
    public CharacterSwapper m_Swapper;

    private void Start()
    {
        m_Swapper = FindObjectOfType<CharacterSwapper>();
    }

    private void Update()
    {
        if (m_Swapper.m_IsGiant)
        {
            if (m_Swapper.m_Giant.GetComponent<GiantController>().m_IsBaby)
            {
                transform.position = Vector3.MoveTowards(transform.position, m_Swapper.m_Giant.GetComponent<GiantController>().m_Model.transform.position, Time.deltaTime * 15f);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, m_Swapper.m_Giant.transform.position, Time.deltaTime * 15f);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, m_Swapper.m_Boy.transform.position, Time.deltaTime * 15f);
        }
    }

    private void OnTriggerEnter(Collider _other)
    {
        if(m_Swapper.m_IsGiant)
        {
            if(_other.tag == "Giant")
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (_other.tag == "Boy")
            {
                Destroy(gameObject);
            }
        }
        
    }
}
