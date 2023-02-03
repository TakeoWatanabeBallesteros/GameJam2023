using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeState : MonoBehaviour,State
{
    public FSM fsm
    {
        get
        {
            return GetComponent<FSM>();
        }
    }

    bool isOnTree;
    Vector3 groundPos;
    [SerializeField] float runVelocity;
    GameObject startPos;
    Transform enemyParent;

    void State.OnEnter()
    {
        groundPos = GetComponent<AppearState>().finalGroundPos;
        Debug.Log(groundPos);
        enemyParent = transform.parent;
    }

    void State.OnUpdate()
    {
        if (isOnTree)
        {
            transform.position = Vector3.Lerp(transform.position, groundPos, runVelocity * Time.deltaTime);
            Vector3 dir = groundPos - transform.position;
            if (dir.magnitude < 0.1f)
            {
                isOnTree = false;
            }
        }
        else
        {
            enemyParent.transform.rotation = Quaternion.Lerp(enemyParent.transform.rotation, startPos.transform.rotation, runVelocity * Time.deltaTime);
            if(enemyParent.transform.eulerAngles.z - startPos.transform.eulerAngles.z < 2 && enemyParent.transform.eulerAngles.z - startPos.transform.eulerAngles.z > -2)
            {
                Destroy(gameObject);
            }
        }
    }
    public void SetStartPos(GameObject startPos)
    {
        this.startPos = startPos;
        //Debug.Log(this.startPos.transform.eulerAngles.z);
    }

    void State.OnExit()
    {

    }
    public void OnTrigger(Collider2D collision)
    {

    }
    public void SetIsOnTree(bool isTree)
    {
        isOnTree = isTree;
    }
}
