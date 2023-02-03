using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUpController : MonoBehaviour
{
    [SerializeField] GameObject desicion;   
    [SerializeField] GameObject button1;
    [SerializeField] GameObject button2;
    [SerializeField] Camera cameraPos;
    bool canInstantiate = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canInstantiate)
        {
            if(collision.tag == "Player")
            {
                Instantiate(desicion, new Vector3(cameraPos.transform.position.x, cameraPos.transform.position.y, 0), Quaternion.identity);
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
}
