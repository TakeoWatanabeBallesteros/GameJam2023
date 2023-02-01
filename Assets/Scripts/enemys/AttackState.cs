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
    [SerializeField] float planetHeight;
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

            Vector3 spawnPosEnemie = enemies[i].transform.position;
            enemies[i].transform.position = Vector3.zero;
            enemies[i].transform.GetChild(0).position = spawnPosEnemie;
            Vector3 dir = enemies[i].transform.GetChild(0).position - enemies[i].transform.position;
            enemies[i].transform.rotation = Quaternion.LookRotation(dir);
            enemies[i].transform.GetChild(0).position = new Vector3(0, planetHeight, 0);
            Debug.Break();
            yield return null;
        }
    }

    void State.OnUpdate()
    {
        foreach (var enemie in enemies)
        {
        }
        //fsm.ChangeState<AttackState>();
    }

    void State.OnExit()
    {

    }
}
