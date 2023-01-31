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

    [SerializeField] List<Transform> spawnPos;
    GameObject[] enemies;
    [SerializeField] GameObject EnemyPrefab;
    private void Awake()
    {
        enemies = new GameObject[spawnPos.Count];
    }

    void State.OnEnter()
    {
        StartCoroutine(spawnEnemy());
    }
    IEnumerator spawnEnemy()
    {
        for (int i = 0; i < spawnPos.Count; i++)
        {
            enemies[i] = Instantiate(EnemyPrefab, spawnPos[i].position, Quaternion.identity);
            yield return null;
        }

    }

    void State.OnUpdate()
    {
        foreach (var enemie in enemies)
        {
            enemie.transform.rotation = 
        }
        fsm.ChangeState<AttackState>();
    }

    void State.OnExit()
    {

    }
}
