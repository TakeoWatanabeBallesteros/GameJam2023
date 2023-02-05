using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GetSun : MonoBehaviour
{
    [SerializeField] GameObject itemPrefab;
    GameObject player;
    PlayerItems playerItemsScript;
    [SerializeField] int maxItemGetPerHit;
    [SerializeField] int minItemGetPerHit;
    [SerializeField] int maxHits;
    [SerializeField] int minHits;
    [SerializeField] float maxTimePerHit;
    [SerializeField] float minTimePerHit;

    [SerializeField] GameObject textPrefab;

    int totalHits;
    int hits;
    [SerializeField] float dissapearTime;
    float timer = 0;
    [SerializeField] GameObject particleDissapear;
    bool gettingItems = false;
    GetCloseToGetitem getClose;

    // Start is called before the first frame update
    void Start()
    {
        totalHits = Random.Range(minHits, maxHits);
        hits = 0;
        timer = Time.time + dissapearTime;
        player = GameObject.FindGameObjectWithTag("Player");
        playerItemsScript = player.GetComponent<PlayerItems>();
        getClose = GetComponent<GetCloseToGetitem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timer)
        {
            Destroy(gameObject);
            Destroy(gameObject.transform.parent.gameObject);
            Instantiate(particleDissapear, transform.position, Quaternion.identity);
        }
        if (getClose.isInRange)
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                gettingItems = false;
            }
            else
            {
                gettingItems = transform;
            }
        }
    }

    public IEnumerator GetItemSun()
    {
        for (int i = hits; i <= totalHits; i++)
        {
            int itemPerHit = Random.Range(minItemGetPerHit, maxItemGetPerHit);
            float timePerHit = Random.Range(minTimePerHit, maxTimePerHit);

            yield return new WaitForSeconds(timePerHit);

            playerItemsScript.ChangeSunItems(itemPerHit);

            GameObject popUpText = Instantiate(textPrefab, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
            popUpText.GetComponentInChildren<TextMeshPro>().text = "+" + itemPerHit.ToString();

            Instantiate(itemPrefab, transform.position, Quaternion.identity);
            hits++;
            totalHits = Random.Range(minHits, maxHits);
        }
        hits = 0;
        Instantiate(particleDissapear, transform.position, Quaternion.identity);
        Destroy(gameObject.transform.parent.gameObject);
        Destroy(gameObject);
    }
    public void DoubleItem()
    {
        maxItemGetPerHit *= 2;
        minItemGetPerHit += 2;
    }
}