using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    int totalHits;
    int hits;

    // Start is called before the first frame update
    void Start()
    {
        totalHits = Random.Range(minHits, maxHits);
        hits = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator GetItemCaca()
    {
        for (int i = hits; i <= totalHits; i++)
        {
            int itemPerHit = Random.Range(minItemGetPerHit, maxItemGetPerHit);
            float timePerHit = Random.Range(minTimePerHit, maxTimePerHit);

            yield return new WaitForSeconds(timePerHit);

            Debug.Log(itemPerHit);
            playerItemsScript.cacaItems += itemPerHit;

            Instantiate(itemPrefab, transform.position, Quaternion.identity);
            hits++;

        }
        Destroy(gameObject);
    }
}
