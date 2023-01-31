using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveItemToPlayer : MonoBehaviour
{
    Transform player;
    float timer;
    Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time + .5f;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Slerp(transform.position, player.position, 0.01f);
        if (Time.time >= timer)
        {
            Destroy(gameObject);
        }
    }
}
