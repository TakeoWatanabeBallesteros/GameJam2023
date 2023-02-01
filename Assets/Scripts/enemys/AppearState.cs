using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearState : MonoBehaviour,State
{
    public FSM fsm
    {
        get
        {
            return GetComponent<FSM>();
        }
    }

    [SerializeField] GameObject treePos;
    GameObject enemyParent;
    [SerializeField] float enemySpeed;
    [SerializeField] float enemySpeedTree;
    bool canMove;

    [SerializeField] Vector3 treeEnemyAttackPosRandom1;
    [SerializeField] Vector3 treeEnemyAttackPosRandom2;

    Vector3 enemyAttackPos;
    public Vector3 startPos;
    public Vector3 finalGroundPos;

    private void Awake()
    {
        enemyParent = transform.parent.gameObject;
        canMove = false;
        startPos = transform.position;
    }

    void State.OnEnter()
    {
        enemyAttackPos = new Vector2(Random.Range(treeEnemyAttackPosRandom1.x, treeEnemyAttackPosRandom2.x), Random.Range(treeEnemyAttackPosRandom1.y, treeEnemyAttackPosRandom2.y));
        StartCoroutine(CanMove());
    }
    IEnumerator CanMove()
    {
        yield return new WaitForSeconds(1f);
        canMove = true;
    }

    void State.OnUpdate()
    {
        if (canMove)
        {
            if (enemyParent.transform.eulerAngles.z > 356 || enemyParent.transform.eulerAngles.z < 4)
            {
                fsm.ChangeState<UpTreeState>();
            }
            else
            {
                enemyParent.transform.rotation = Quaternion.Lerp(enemyParent.transform.rotation, treePos.transform.rotation, enemySpeed * Time.deltaTime);
                finalGroundPos = transform.position;
            }
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
