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

   

    void State.OnEnter()
    {

    }

    void State.OnUpdate()
    {
       
    }

    void State.OnExit()
    {

    }
}
