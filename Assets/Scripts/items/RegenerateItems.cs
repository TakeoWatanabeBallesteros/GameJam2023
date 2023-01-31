using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenerateItems : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void regenerate(GameObject item, Vector3 pos, Quaternion rotation, float regenerateTime)
    {
        StartCoroutine(RegenerateItem(item, pos, rotation, regenerateTime));
    }
    public IEnumerator RegenerateItem(GameObject item, Vector3 pos, Quaternion rotation, float regenerateTime)
    {
        Debug.Log("wor");
        yield return new WaitForSeconds(3);
        Debug.Log("working");
        Instantiate(item, pos, rotation);
    }
}
