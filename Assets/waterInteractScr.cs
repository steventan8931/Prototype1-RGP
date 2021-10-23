using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterInteractScr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Boy")
        {
            other.gameObject.GetComponent<Boy>().m_Inwater = true;
        }
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Boy")
        {
            //Boy scr die
            collision.gameObject.GetComponent<Boy>().m_Inwater = true;
        }
    }*/
}
