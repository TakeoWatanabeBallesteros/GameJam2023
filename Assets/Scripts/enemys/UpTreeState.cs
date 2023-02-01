using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpTreeState : MonoBehaviour,State
{
    public FSM fsm
    {
        get
        {
            return GetComponent<FSM>();
        }
    }
   
    [SerializeField] float enemySpeedTree;

    [SerializeField] Vector3 treeEnemyAttackPosRandom1;
    [SerializeField] Vector3 treeEnemyAttackPosRandom2;

    Vector3 enemyAttackPos;

    public Vector3 finalGroundPos;


    void State.OnEnter()
    {
        enemyAttackPos = new Vector2(Random.Range(treeEnemyAttackPosRandom1.x, treeEnemyAttackPosRandom2.x), Random.Range(treeEnemyAttackPosRandom1.y, treeEnemyAttackPosRandom2.y));
        finalGroundPos = transform.position;
        Debug.Log(enemyAttackPos);
    }

    void State.OnUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, enemyAttackPos, enemySpeedTree * Time.deltaTime);
        Vector3 dir = enemyAttackPos - transform.position;
        if (dir.magnitude < 0.01f)
        {
            fsm.ChangeState<AttackState>();
        }
    }

    void State.OnExit()
    {

    }
    public void OnTrigger(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            fsm.ChangeState<FleeState>();
        }
    }
}
