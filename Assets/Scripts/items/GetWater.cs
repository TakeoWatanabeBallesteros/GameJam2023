using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator GetItemWater()
    {
        int hits = Random.Range(minHits, maxHits);

        for (int i = 0; i <= hits; i++)
        {
            int itemPerHit = Random.Range(minItemGetPerHit, maxItemGetPerHit);
            float timePerHit = Random.Range(minTimePerHit, maxTimePerHit);

            yield return new WaitForSeconds(timePerHit);

            playerItemsScript.waterItems = itemPerHit;

            GameObject itemToPlayer = Instantiate(itemPrefab, transform.position, Quaternion.identity);


        }
    }
}
