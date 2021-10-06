using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weeBabyScr : MonoBehaviour
{
    public bool istriggered = false;
    public GameObject OldGiant, butcherGiant;
    public Transform loc1, loc2;
    public GameObject boy;
    public float moveSpeed = 7f;
    // Start is called before the first frame update
    void Start()
    {
        summonGiants();
        boy = GameObject.FindGameObjectWithTag("boy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Vector3 moveTowards(GameObject target)
    {
        return Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed);

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

    public void ChargeToPlayer()
    {
        Vector3 tempTarget = boy.transform.position;
        tempTarget.y = gameObject.transform.position.y;
        transform.LookAt(tempTarget);
        transform.position = moveTowards(GameObject.FindGameObjectWithTag("boy"));
    }
}
