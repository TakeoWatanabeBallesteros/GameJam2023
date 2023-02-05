using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaBehaviour : MonoBehaviour
{
    public Transform planetPivot;
    public GameObject lats;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform GetPlanetPivot() => planetPivot;

    public void UnblockLats()
    {
        lats.SetActive(false);
    }
    
    public void BlockLats()
    {
        lats.SetActive(true);
    }
}
