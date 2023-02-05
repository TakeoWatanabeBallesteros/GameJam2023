using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GetWater : MonoBehaviour
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

    [SerializeField] GameObject textPrefab;

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] CircleCollider2D circleCollider;

    int totalHits;
    int hits;
    [SerializeField] float regenerateTime;
    bool gettingItems = false;
    GetCloseToGetitem getClose;
    [SerializeField] GameObject particlePrefab;
    [SerializeField] GameObject particleDissapearPrefab;

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

    public IEnumerator GetItemWater()
    {
        if (player.GetComponent<PlayerItems>().waterItems < player.GetComponent<PlayerItems>().limitItem)
        {
            for (int i = hits; i <= totalHits; i++)
            {
                int itemPerHit = Random.Range(minItemGetPerHit, maxItemGetPerHit);
                float timePerHit = Random.Range(minTimePerHit, maxTimePerHit);

                yield return new WaitForSeconds(timePerHit);

                playerItemsScript.ChangeWaterItems(itemPerHit);

                GameObject popUpText = Instantiate(textPrefab, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
                popUpText.GetComponentInChildren<TextMeshPro>().text = "+" + itemPerHit.ToString();

                Instantiate(itemPrefab, transform.position, Quaternion.identity);
                hits++;
                totalHits = Random.Range(minHits, maxHits);
            }
            hits = 0;
            StartCoroutine(regenerateItem());
        }           
    }
    IEnumerator regenerateItem()
    {
        spriteRenderer.enabled = false;
        circleCollider.enabled = false;
        GameObject particleDisapear = Instantiate(particleDissapearPrefab, transform.position, transform.rotation);
        yield return new WaitForSeconds(2f);
        Destroy(particleDisapear);
        yield return new WaitForSeconds(regenerateTime);
        spriteRenderer.enabled = true;
        circleCollider.enabled = true;
        GameObject particle = Instantiate(particlePrefab, transform.position, transform.rotation);
        yield return new WaitForSeconds(1f);
        Destroy(particle);
    }
    public void DoubleItem()
    {
        maxItemGetPerHit *= 2;
        minItemGetPerHit += 2;
    }
}