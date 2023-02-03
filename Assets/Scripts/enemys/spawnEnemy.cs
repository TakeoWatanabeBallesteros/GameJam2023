using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    [SerializeField] List<GameObject> spawnPos;
    GameObject[] enemies;
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] float planetHeight;
    public string planetTreeName;
    public bool hasRadar = false;
    // Start is called before the first frame update
    void Start()
    {
        enemies = new GameObject[spawnPos.Count];
        StartCoroutine(spawnEnemyInPos());
    }

    IEnumerator spawnEnemyInPos()
    {
        for (int i = 0; i < spawnPos.Count; i++)
        {
            enemies[i] = Instantiate(EnemyPrefab, spawnPos[i].transform.GetChild(0).position, Quaternion.identity);

            Vector3 spawnPosEnemie = enemies[i].transform.position;
            enemies[i].transform.position = Vector3.zero;    
            Vector3 dir = spawnPosEnemie - enemies[i].transform.position;
            enemies[i].transform.GetChild(0).position = new Vector3(0, planetHeight, 0);
            //enemies[i].transform.rotation = Quaternion.LookRotation(dir);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            enemies[i].transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);     
            enemies[i].transform.rotation = Quaternion.Euler(0, 0, enemies[i].transform.eulerAngles.z - 90);

            if(enemies[i].transform.eulerAngles.z > 180)
            {
                Debug.Log("hola");
                enemies[i].transform.GetChild(0).localScale = new Vector3(enemies[i].transform.GetChild(0).localScale.x * -1, enemies[i].transform.GetChild(0).localScale.y, enemies[i].transform.GetChild(0).localScale.z);
                enemies[i].transform.GetChild(0).GetComponent<Animator>().SetTrigger("appearLeft");
            }
            enemies[i].GetComponentInChildren<FleeState>().SetStartPos(spawnPos[i]);
            yield return null;
        }
    }
    public void EspantabichosPowerUp()
    {

    }
}
