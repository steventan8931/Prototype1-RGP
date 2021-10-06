using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weeBabyScr : MonoBehaviour
{
    public bool istriggered = false;
    public GameObject OldGiant, butcherGiant;
    public Transform loc1, loc2;
    // Start is called before the first frame update
    void Start()
    {
        summonGiants();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void summonGiants()
    {
        Instantiate(OldGiant,loc1.position,loc1.rotation);
        Instantiate(butcherGiant, loc2.position,loc2.rotation);
    }

    public void triggerBaby()
    {
        istriggered = true;
    }
}
