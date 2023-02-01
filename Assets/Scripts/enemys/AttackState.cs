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
    [SerializeField] SpriteRenderer treeSprite;
    float timer;
    [SerializeField] float timeToAttack;

    private void Awake()
    {
        treeSprite = GameObject.FindGameObjectWithTag("tree1").GetComponent<SpriteRenderer>();
    }

    void State.OnEnter()
    {
        Debug.Log("done");
        timer = Time.time + timeToAttack;
    }


    void State.OnUpdate()
    {
        
        if(Time.time > timer)
        {
            Debug.Log(treeSprite);
            treeSprite.material.SetFloat("Grow", 0); 
        }
    }

    void State.OnExit()
    {

    }
}
