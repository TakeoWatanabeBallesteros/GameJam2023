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
    Animator animator;
    spawnEnemy spawn;

    void State.OnEnter()
    {
        groundPos = GetComponent<AppearState>().finalGroundPos;

        enemyParent = transform.parent;
        animator = GetComponent<Animator>();
        animator.SetBool("attack", false);
        //spawn = GameObject.FindGameObjectWithTag("SpawnEnemy").GetComponent<spawnEnemy>();
    }

    void State.OnUpdate()
    {
        if (isOnTree)
        {
            enemyParent.position = Vector3.Lerp(enemyParent.position, groundPos, runVelocity * Time.deltaTime);
            Vector3 dir = groundPos - enemyParent.position;
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
                if(startPos.transform.eulerAngles.z > 180)
                {
                    animator.SetTrigger("die");
                }
                else
                {
                    animator.SetTrigger("dieLeft");
                }
                //spawn.CanAppearEnemy();


                StartCoroutine(DestroyEnemy());
            }
        }
    }
    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(1.5f);
        
            Destroy(gameObject.transform.parent.gameObject);
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
