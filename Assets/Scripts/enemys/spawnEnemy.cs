using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnEnemy : MonoBehaviour
{
    [SerializeField] List<GameObject> spawnPos;
    public GameObject[] enemies;
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] float planetHeight;
    public string planetTreeName;
    public bool hasRadar = false;
    float timer;
    [SerializeField] float timeToAppear1;
    [SerializeField] float timeToAppear2;
    bool canAppear = true;
    [SerializeField] Image alertImage;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new GameObject[spawnPos.Count];
        timer = Time.time + Random.Range(timeToAppear1, timeToAppear2);
    }
    private void Update()
    {
        if (canAppear && Time.time > timer)
        {
            canAppear = false;
            if (hasRadar)
            {
                Debug.Log("sad");
                StartCoroutine(Alert());
            }
            StartCoroutine(spawnEnemyInPos());

        }
        else if (!canAppear)
        {
            int numEnemy = 0;
            foreach (var item in enemies)
            {
                if(item != null)
                {
                    numEnemy += 1;
                }
            }
            if(numEnemy == 0)
            {
                CanAppearEnemy();
            }
        }
    }
    IEnumerator Alert()
    {
        Color colorImage =  alertImage.color;
        colorImage.a = .7f;
        alertImage.color = colorImage;
        while (alertImage.color.a > 0)
        {
            colorImage.a -= .001f;
            alertImage.color = colorImage;
            yield return null;
        }

    }
    public void CanAppearEnemy()
    {
        timer = Time.time + Random.Range(timeToAppear1, timeToAppear2);
        canAppear = true;
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
                enemies[i].transform.GetChild(0).localScale = new Vector3(enemies[i].transform.GetChild(0).localScale.x * -1, enemies[i].transform.GetChild(0).localScale.y, enemies[i].transform.GetChild(0).localScale.z);
                enemies[i].transform.GetChild(0).GetComponent<Animator>().SetTrigger("appearLeft");
            }
            enemies[i].GetComponentInChildren<FleeState>().SetStartPos(spawnPos[i]);
            yield return null;
        }
    }
    public void EspantabichosPowerUp()
    {
        timeToAppear1 *= 2;
        timeToAppear2 *= 2;
    }
}
