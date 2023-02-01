using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunAppear : MonoBehaviour
{
    [SerializeField] GameObject sunItem;
    [SerializeField] Vector3 appearPos;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(sunItem, appearPos, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
