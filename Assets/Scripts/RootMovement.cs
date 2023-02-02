using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RootMovement : MonoBehaviour
{
    public float rootMaxHeight;
    public Transform pivotTransform;
    [Range(0f, 74)] public float rootHeight;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        pivotTransform.position = new Vector3(0, rootHeight-2.4f, 0);
        spriteRenderer.material.SetFloat("_grow", 1 - (rootHeight / rootMaxHeight)+.08f);
    }
    
    
}
