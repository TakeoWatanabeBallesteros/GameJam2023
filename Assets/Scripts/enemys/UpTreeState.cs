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
    Animator animator;
    Transform enemyFather;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemyFather = transform.parent;
    }


    void State.OnEnter()
    {
        enemyAttackPos = new Vector2(Random.Range(treeEnemyAttackPosRandom1.x, treeEnemyAttackPosRandom2.x), Random.Range(treeEnemyAttackPosRandom1.y, treeEnemyAttackPosRandom2.y));
        finalGroundPos = enemyFather.position;

        animator.SetBool("attack", false);
    }

    void State.OnUpdate()
    {
        enemyFather.position = Vector3.Lerp(enemyFather.position, enemyAttackPos, enemySpeedTree * Time.deltaTime);
        Vector3 dir = enemyAttackPos - enemyFather.position;
        if (dir.magnitude < 0.1f)
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
            GetComponent<FleeState>().SetIsOnTree(true);
            fsm.ChangeState<FleeState>();           
        }
    }
}
