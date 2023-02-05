using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    

    public void Patitas()
    {
        // Play audio here
        FindObjectOfType<AudioManager>().Play("rock");
    }

    public void Cogeme()
    {
        // Play audio here
        FindObjectOfType<AudioManager>().Play("escalar");
    }
}
