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

    [SerializeField] GameObject textPrefab;

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
            playerItemsScript.ChangeCacaItems(itemPerHit);

            GameObject popUpText = Instantiate(textPrefab, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
            popUpText.GetComponentInChildren<TextMeshPro>().text = "+" + itemPerHit.ToString();

            Instantiate(itemPrefab, transform.position, Quaternion.identity);
            hits++;

        }
        Destroy(gameObject);
    }
}
