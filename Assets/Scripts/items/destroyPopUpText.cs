using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyPopUpText : MonoBehaviour
{
    [SerializeField] float destroyTime;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time + destroyTime; 
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timer)
        {
            Destroy(gameObject);
        }
    }
}
