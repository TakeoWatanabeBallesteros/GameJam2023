using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUpController : MonoBehaviour
{
    [SerializeField] GameObject desicionPrefab;   
    [SerializeField] GameObject button1;
    [SerializeField] GameObject button2;
    [SerializeField] Camera cameraPos;
    bool canInstantiate = true;
    GameObject decision = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canInstantiate)
        {
            if(collision.tag == "Player")
            {
                decision = Instantiate(desicionPrefab, new Vector3(cameraPos.transform.position.x, cameraPos.transform.position.y, 0), Quaternion.identity);
                canInstantiate = false;
                StartCoroutine(SpawnButtons());
            }
        }
        
    }
    IEnumerator SpawnButtons()
    {
        yield return new WaitForSeconds(1f);
        button1.SetActive(true);
        button2.SetActive(true);
    }
    public void DestroyDesicion()
    {
        button1.SetActive(false);
        button2.SetActive(false);
        decision.transform.GetChild(0).GetComponent<Animator>().SetTrigger("dissapear");
        StartCoroutine(DestroyDesicion(decision));
    }
    IEnumerator DestroyDesicion(GameObject desicion)
    {
        yield return new WaitForSeconds(1f);
        Destroy(desicion);
    }
}
