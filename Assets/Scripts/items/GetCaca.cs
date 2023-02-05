using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GetCaca : MonoBehaviour
{
    [SerializeField] GameObject itemPrefab;
    [SerializeField] GameObject player;
    [SerializeField] PlayerItems playerItemsScript;
    [SerializeField] int maxItemGetPerHit;
    [SerializeField] int minItemGetPerHit;
    [SerializeField] int maxHits;
    [SerializeField] int minHits;
    [SerializeField] float maxTimePerHit;
    [SerializeField] float minTimePerHit;

    [SerializeField] float regenerateTime;

    [SerializeField] GameObject textPrefab;

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] CircleCollider2D circleCollider;

    int totalHits;
    int hits;
    bool gettingItems = false;
    GetCloseToGetitem getClose;

    // Start is called before the first frame update
    void Start()
    {
        totalHits = Random.Range(minHits, maxHits);
        hits = 0;
        getClose = GetComponent<GetCloseToGetitem>();
    }

    // Update is called once per frame
    void Update()
    {
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

    public IEnumerator GetItemCaca()
    {
        for (int i = hits; i <= totalHits; i++)
        {
            int itemPerHit = Random.Range(minItemGetPerHit, maxItemGetPerHit);
            float timePerHit = Random.Range(minTimePerHit, maxTimePerHit);

            yield return new WaitForSeconds(timePerHit);

            playerItemsScript.ChangeCacaItems(itemPerHit);

            GameObject popUpText = Instantiate(textPrefab, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
            popUpText.GetComponentInChildren<TextMeshPro>().text = "+" + itemPerHit.ToString();

            Instantiate(itemPrefab, transform.position, Quaternion.identity);
            hits++;
            totalHits = Random.Range(minHits, maxHits);
        }
        hits = 0;
        StartCoroutine(regenerateItem());
    }
    IEnumerator regenerateItem()
    {
        spriteRenderer.enabled = false;
        circleCollider.enabled = false;
        yield return new WaitForSeconds(regenerateTime);
        spriteRenderer.enabled = true;
        circleCollider.enabled = true;
    }
    public void DoubleItem()
    {
        maxItemGetPerHit *= 2;
        minItemGetPerHit += 2;
    }

}
