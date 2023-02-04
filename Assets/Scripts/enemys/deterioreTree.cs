using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deterioreTree : MonoBehaviour
{
    SpriteRenderer spriteTree;
    float life = 1;
    float lifeLerp = 1;
    [SerializeField] float deterioreTime;
    bool canDamage = true;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        spriteTree = GetComponent<SpriteRenderer>();
    }
    public void DamageTree(float damage)
    {
        if (canDamage)
        {
            life -= damage;
            canDamage = false;
            Debug.Log("dmg");
        }          
    }

    // Update is called once per frame
    void Update()
    {
        lifeLerp = Mathf.Lerp(lifeLerp, life, deterioreTime * Time.deltaTime);
        spriteTree.material.SetFloat("_grow", lifeLerp);
        if (!canDamage)
        {
            timer += Time.deltaTime;
            if(timer > 1)
            {
                canDamage = true;
                timer = 0;
            }
        }
    }
}
