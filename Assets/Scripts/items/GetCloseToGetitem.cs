using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCloseToGetitem : MonoBehaviour
{
    IEnumerator cacaCoroutine;
    IEnumerator waterCoroutine;
    IEnumerator windCoroutine;
    IEnumerator sunCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetComponent<GetCaca>() != null)
        {
            cacaCoroutine = GetComponent<GetCaca>().GetItemCaca();
            StartCoroutine(cacaCoroutine);
        }
        else if (GetComponent<GetWater>() != null)
        {
            waterCoroutine = GetComponent<GetWater>().GetItemWater();
            StartCoroutine(waterCoroutine);
        }
        else if (GetComponent<GetWind>() != null)
        {
            windCoroutine = GetComponent<GetWind>().GetItemWind();
            StartCoroutine(windCoroutine);
        }
        else if (GetComponent<GetSun>() != null)
        {
            sunCoroutine = GetComponent<GetSun>().GetItemSun();
            StartCoroutine(sunCoroutine);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (GetComponent<GetCaca>() != null)
        {
            StopCoroutine(cacaCoroutine);
        }
        else if (GetComponent<GetWater>() != null)
        {
            StopCoroutine(waterCoroutine);
        }
        else if (GetComponent<GetWind>() != null)
        {
            StopCoroutine(windCoroutine);
        }
        else if (GetComponent<GetSun>() != null)
        {
            StopCoroutine(sunCoroutine);
        }
    }
}
