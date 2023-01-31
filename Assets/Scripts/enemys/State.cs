using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface State
{
    FSM fsm { get;}
    public void OnEnter();
    public void OnUpdate();
    public void OnExit();
}


