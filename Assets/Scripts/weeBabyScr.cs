using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weeBabyScr : MonoBehaviour
{
    //setup for moving ai
    public bool istriggered = false;
    public GameObject OldGiant, butcherGiant;
    public Transform loc1, loc2;
    public GameObject boy;
    
    public float moveSpeed = 0.2f;
    Vector3 target;

    //setup for field of view
    public FieldOfView FoV;
    public float chargeTime = 5f;
    public float currChargeTime = 0f;
    public bool isCharging = false;
    public bool targetlocked = false;
    // Start is called before the first frame update
    void Start()
    {
        summonGiants();
        boy = GameObject.FindGameObjectWithTag("boy");
    }

    // Update is called once per frame
    void Update()
    {
        chargeProcess();
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
    // 1.player enter view range of baby
    // 2. trigger baby and set the target
    // 3. charge to player's location
    public void triggerBaby()
    {
        istriggered = true;
        setTarget();
    }
    public void setTarget()
    {
        target = boy.transform.position;
        target.y = gameObject.transform.position.y;
    }
    public void ChargeToPlayer()
    {
        transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed);
    }
    private void chargeProcess()
    {
        if (FoV.canSeePlayer == true && targetlocked == false && isCharging == false)
        {
            targetlocked = true;
            triggerBaby();
            currChargeTime = chargeTime;
            isCharging = true;
            print("locked boy!");
        }
        if(isCharging && currChargeTime > 0)
        {
            ChargeToPlayer();
            currChargeTime -= Time.deltaTime;
            print("charging");
        }
        if(currChargeTime <= 0)
        {
            targetlocked = false;
            isCharging = false;
            currChargeTime = 0;
            print("targetlost");
        }
        
    }
    
}
