using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnUI : MonoBehaviour
{
    public GameObject burnUI;
    public GameObject manager;
   

    // Update is called once per frame
    void Update()
    {
        if(manager.GetComponent<GameState>().m_BoyDead)
        {
            burnUI.SetActive(true);
        }else
        {
            burnUI.SetActive(false);
        }
        
    }
}
