using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public AudioSource m_Audio;
    public float m_Timer = 0.0f;
    public bool m_Touched = false;
    private void OnTriggerEnter(Collider _other)
    {
        if (_other.GetComponent<Death>() != null)
        {
            m_Touched = true;
            _other.GetComponent<Death>().m_TouchedWater = true;
            m_Audio.Play();
        }
    }

    public void Update()
    {
        if (m_Touched)
        {
            m_Timer += Time.deltaTime;

            if (m_Timer > 0.3)
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
