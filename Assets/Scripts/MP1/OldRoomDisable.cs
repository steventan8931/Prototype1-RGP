using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldRoomDisable : MonoBehaviour
{
    public MusicBoxScr m_MusicBox;
    public AudioSource musicBoxSfx;
    public GiantController m_Giant;
    public butcherScr butcher;
    public int m_RoomsCleared = 0;
    Boy cahceBoy;

    public GameObject m_Camera;

    bool doOnce = false;
    bool triggered = false;

    private void Start()
    {
        butcher = FindObjectOfType<butcherScr>();
        cahceBoy = FindObjectOfType<Boy>();
    }
    //On Triggers Makes Specific Room Giant uncontrollable and Music stop playing
    private void OnTriggerEnter(Collider _other)
    {
        if (_other.tag == "Boy")
        {
            if (_other.GetComponent<Boy>() != null)
            {
                if (!doOnce)
                {
                    m_Camera.SetActive(true);
                    triggered = true;
                    doOnce = true;
                }

                _other.GetComponent<Boy>().m_RoomsCleared = m_RoomsCleared;
                if (m_Giant.GetComponent<GiantOneAI>() != null)
                {
                    m_Giant.GetComponent<GiantOneAI>().enabled = false;
                    m_Giant.StopSnoring();
                }

                if (m_RoomsCleared == 1)
                {
                    if (m_Giant.GetComponent<butcherScr>() != null)
                    {
                        m_Giant.GetComponent<butcherScr>().enabled = false;
                        m_Giant.StopSnoring();
                    }
                }
                m_MusicBox.isactive = false;
                musicBoxSfx.Stop();
                m_Giant.m_Controllable = false;
                

            }
        }

        if (_other.tag == "Giant")
        {
            if (m_Giant.GetComponent<GiantOneAI>().enabled)
            {
                m_Giant.GetComponent<CharacterSwapper>().Swap();
                m_Giant.GetComponent<GiantController>().m_IsControl = false;
                m_Giant.GetComponent<GiantController>().m_Look.m_AttachedCamera.enabled = false;
                cahceBoy.GetComponent<Boy>().m_IsControl = true;
                cahceBoy.GetComponent<Boy>().m_Look.m_AttachedCamera.enabled = true;
                m_MusicBox.isactive = false;
                m_Giant.m_Controllable = false;
                m_Giant.m_Animation.SetBool("Walking", false);
                m_Giant.m_Animation.SetBool("Pushing", false);
                m_Giant.GetComponent<GiantOneAI>().enabled = false;
                m_Giant.StopSnoring();

            }
        }
    }

    private void Update()
    {
        if (triggered)
        {
            Invoke("SetUpButcher", 1.5f);
            triggered = false;
        }
    }
    void SetUpButcher()
    {
        butcher.isIdling = false;
        butcher.isSleep = false;
        print("butcher woken");
    }
}
