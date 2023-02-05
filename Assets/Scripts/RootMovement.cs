using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RootMovement : MonoBehaviour
{
    public float rootMaxHeight;
    public Transform pivotTransform;
    [Range(2, 32)] public float rootHeight;
    private SpriteRenderer spriteRenderer;
    
    public int[] stage1 = new int[5];
    public int[] stage2 = new int[5];
    public int[] stage3 = new int[5];
    public int[] stage4 = new int[5];
    public int[] stage5 = new int[5];
    
    public int stage = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        pivotTransform.position = new Vector3(0, rootHeight + 1, 0);
        spriteRenderer.material.SetFloat("_grow", Mathf.Lerp(spriteRenderer.material.GetFloat("_grow"), Scale(2, rootMaxHeight, rootHeight), Time.deltaTime));
    }
    
    private static float Scale(float min, float max, float value)
    {
        return Mathf.Clamp(1 / (max - min) * (value - max) + 1, 0, 1);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerItems items = other.GetComponent<PlayerItems>();
        switch (stage)
        {
           case 1:
               if (stage1[0] > 0)
               {
                   int s = stage1[0];
                   stage1[0] -= items.tierraItems;
                   items.tierraItems -= s;
               }
               if (stage1[1] > 0)
               {
                   int s = stage1[1];
                   stage1[1] -= items.waterItems;
                   items.waterItems -= s;
               }
               if (stage1[2] > 0)
               {
                   int s = stage1[2];
                   stage1[2] -= items.sunItems;
                   items.sunItems -= s;
               }
               if (stage1[3] > 0)
               {
                   int s = stage1[3];
                   stage1[3] -= items.cacaItems;
                   items.cacaItems -= s;
               }
               if (stage1[4] > 0)
               {
                   int s = stage1[4];
                   stage1[4] -= items.windItems;
                   items.windItems -= s;
               }
               break;
           case 2:
               if (stage2[0] > 0)
               {
                   int s = stage2[0];
                   stage2[0] -= items.tierraItems;
                   items.tierraItems -= s;
               }
               if (stage2[1] > 0)
               {
                   int s = stage2[1];
                   stage2[1] -= items.waterItems;
                   items.waterItems -= s;
               }
               if (stage2[2] > 0)
               {
                   int s = stage2[2];
                   stage2[2] -= items.sunItems;
                   items.sunItems -= s;
               }
               if (stage2[3] > 0)
               {
                   int s = stage2[3];
                   stage2[3] -= items.cacaItems;
                   items.cacaItems -= s;
               }
               if (stage2[4] > 0)
               {
                   int s = stage2[4];
                   stage2[4] -= items.windItems;
                   items.windItems -= s;
               }
               break;
           case 3:
               if (stage3[0] > 0)
               {
                   int s = stage3[0];
                   stage3[0] -= items.tierraItems;
                   items.tierraItems -= s;
               }
               if (stage3[1] > 0)
               {
                   int s = stage3[1];
                   stage3[1] -= items.waterItems;
                   items.waterItems -= s;
               }
               if (stage3[2] > 0)
               {
                   int s = stage3[2];
                   stage3[2] -= items.sunItems;
                   items.sunItems -= s;
               }
               if (stage3[3] > 0)
               {
                   int s = stage3[3];
                   stage3[3] -= items.cacaItems;
                   items.cacaItems -= s;
               }
               if (stage3[4] > 0)
               {
                   int s = stage3[4];
                   stage3[4] -= items.windItems;
                   items.windItems -= s;
               }
               break;
           case 4:
               if (stage4[0] > 0)
               {
                   int s = stage4[0];
                   stage4[0] -= items.tierraItems;
                   items.tierraItems -= s;
               }
               if (stage4[1] > 0)
               {
                   int s = stage4[1];
                   stage4[1] -= items.waterItems;
                   items.waterItems -= s;
               }
               if (stage4[2] > 0)
               {
                   int s = stage4[2];
                   stage4[2] -= items.sunItems;
                   items.sunItems -= s;
               }
               if (stage4[3] > 0)
               {
                   int s = stage4[3];
                   stage4[3] -= items.cacaItems;
                   items.cacaItems -= s;
               }
               if (stage4[4] > 0)
               {
                   int s = stage4[4];
                   stage4[4] -= items.windItems;
                   items.windItems -= s;
               }
               break;
           case 5:
               if (stage5[0] > 0)
               {
                   int s = stage5[0];
                   stage5[0] -= items.tierraItems;
                   items.tierraItems -= s;
               }
               if (stage5[1] > 0)
               {
                   int s = stage5[1];
                   stage5[1] -= items.waterItems;
                   items.waterItems -= s;
               }
               if (stage5[2] > 0)
               {
                   int s = stage5[2];
                   stage5[2] -= items.sunItems;
                   items.sunItems -= s;
               }
               if (stage5[3] > 0)
               {
                   int s = stage5[3];
                   stage5[3] -= items.cacaItems;
                   items.cacaItems -= s;
               }
               if (stage5[4] > 0)
               {
                   int s = stage5[4];
                   stage5[4] -= items.windItems;
                   items.windItems -= s;
               }
               break;
        }
    }
}
