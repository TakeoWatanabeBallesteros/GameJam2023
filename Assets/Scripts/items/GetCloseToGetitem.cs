using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCloseToGetitem : MonoBehaviour
{
    [SerializeField] GetCaca getCacaScript;
    [SerializeField] GetSun  getSunScript;
    [SerializeField] GetWater getWaterScript;
    [SerializeField] GetWind getWindScript;

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
        if (getCacaScript == GetComponent<GetCaca>())
        {
            cacaCoroutine = getCacaScript.GetItemCaca();
            StartCoroutine(cacaCoroutine);
        }
        else if (getWaterScript == GetComponent<GetWater>())
        {
            Debug.Log("cacaasds");
        }
        else if (getWindScript == GetComponent<GetWind>())
        {

            Debug.Log("na");
        }
        else if (getSunScript == GetComponent<GetSun>())
        {
            Debug.Log("nanananananna");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (getCacaScript == GetComponent<GetCaca>())
        {
            StopCoroutine(cacaCoroutine);
        }
        else if (getWaterScript == GetComponent<GetWater>())
        {
            Debug.Log("cacaasds");
        }
        else if (getWindScript == GetComponent<GetWind>())
        {

            Debug.Log("na");
        }
        else if (getSunScript == GetComponent<GetSun>())
        {
            Debug.Log("nanananananna");
        }
    }
}
