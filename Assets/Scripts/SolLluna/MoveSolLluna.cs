using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSolLluna : MonoBehaviour
{
    [SerializeField] float turnSpeed;
    Animator animator;
    bool canChangeSunMoon = true;
    float timer = 0;
    bool move = true;
    [SerializeField] Sprite sunSprite;
    [SerializeField] Sprite moonSprite;
    SpriteRenderer spriteRenderer;
    Transform parentObject;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        parentObject = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        if (parentObject.eulerAngles.z >= 355 && !canChangeSunMoon)
        {
            animator.SetTrigger("changeSunMoon");
            canChangeSunMoon = true;
            move = false;
        }
        else if (parentObject.eulerAngles.z <= 180 && canChangeSunMoon)
        {
            animator.SetTrigger("changeSunMoon");
            canChangeSunMoon = false;
            move = false;
        }

        if (move)
        {
            parentObject.rotation = Quaternion.Slerp(parentObject.rotation, Quaternion.Euler(0, 0, parentObject.eulerAngles.z - 90), turnSpeed * Time.deltaTime);
            if(parentObject.eulerAngles.z< -360)
            {
                parentObject.rotation = Quaternion.Euler(0,0,0);
            }
        }
        else
        {
            if (timerToMove())
            {
                move = true;
            }
        }
    }
    bool timerToMove()
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            timer = 0;
            return true;
        }
        return false;
    }
    public void ChangeSprite()
    {
        if(spriteRenderer.sprite == moonSprite)
        {
            spriteRenderer.sprite = sunSprite;
        }
        else
        {
            spriteRenderer.sprite = moonSprite;
        }
    }
}