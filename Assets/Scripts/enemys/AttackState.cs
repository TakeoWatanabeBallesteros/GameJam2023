using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : MonoBehaviour,State
{
    public FSM fsm
    {
        get
        {
            return GetComponent<FSM>();
        }
    }
    deterioreTree tree;
    float timer;
    [SerializeField] float timeToAttack;
    [SerializeField] float damageToTree;

    private void Awake()
    {
        tree = GameObject.FindGameObjectWithTag("tree1").GetComponent<deterioreTree>();
    }

    void State.OnEnter()
    {
        timer = Time.time + timeToAttack;
    }


    void State.OnUpdate()
    {
        if(Time.time > timer)
        {
            timer = Time.time + timeToAttack;
            tree.DamageTree(damageToTree);
            //fsm.ChangeState<FleeState>();
        }
    }
    public void PlayerIsClose()
    {

    }

    void State.OnExit()
    {

    }
    public void OnTrigger(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GetComponent<FleeState>().SetIsOnTree(true);
            fsm.ChangeState<FleeState>();           
        }
    }
}
