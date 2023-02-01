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

    bool isOnTree = true;
    Vector3 groundPos;
    [SerializeField] float runVelocity;

    void State.OnEnter()
    {
        groundPos = GetComponent<AppearState>().finalGroundPos;
    }

    void State.OnUpdate()
    {
        if (isOnTree)
        {
            transform.position = Vector3.Lerp(transform.position, groundPos, runVelocity * Time.deltaTime);
        }
        else
        {

        }
    }

    void State.OnExit()
    {

    }
    public void OnTrigger(Collider2D collision)
    {

    }
}
