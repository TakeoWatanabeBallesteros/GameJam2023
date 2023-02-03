using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUpController : MonoBehaviour
{
    [SerializeField] GameObject desicion1;
    [SerializeField] GameObject desicion2;
    [SerializeField] GameObject desicion3;
    [SerializeField] GameObject desicion4;
    [SerializeField] GameObject button1;
    [SerializeField] GameObject button2;
    [SerializeField] GameObject button3;
    [SerializeField] GameObject button4;
    [SerializeField] GameObject button5;
    [SerializeField] GameObject button6;
    [SerializeField] GameObject button7;
    [SerializeField] GameObject button8;
    [SerializeField] Camera cameraPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Instantiate(desicion1, new Vector3(cameraPos.transform.position.x, cameraPos.transform.position.y, 0), Quaternion.identity);
            button1.SetActive(true);
            button2.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            Instantiate(desicion2, new Vector3(cameraPos.transform.position.x, cameraPos.transform.position.y, 0), Quaternion.identity);
            button3.SetActive(true);
            button4.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Instantiate(desicion3, new Vector3(cameraPos.transform.position.x, cameraPos.transform.position.y, 0), Quaternion.identity);
            button5.SetActive(true);
            button6.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            Instantiate(desicion4, new Vector3(cameraPos.transform.position.x,cameraPos.transform.position.y,0), Quaternion.identity);
            button7.SetActive(true);
            button8.SetActive(true);
        }   
    }
}
