using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using TMPro;

public class RootMovement : MonoBehaviour
{
    public float rootMaxHeight;
    public Transform pivotTransform;
    [Range(5.1f, 48.8f)] public float rootHeight;
    public SpriteRenderer spriteRenderer;

    public float  rootMinHeight;

    public GameObject canvas;
    
    public int[] stage1 = new int[5];
    public int[] stage2 = new int[5];
    public int[] stage3 = new int[5];
    public int[] stage4 = new int[5];
    public int[] stage5 = new int[5];
    
    [SerializeField] TextMeshProUGUI sunText;
    [SerializeField] TextMeshProUGUI windText;
    [SerializeField] TextMeshProUGUI cacaText;
    [SerializeField] TextMeshProUGUI waterText;
    [SerializeField] TextMeshProUGUI tierraText;

    public PlayerItems plitms;
    
    public int stage = 1;

    private float[] stp = new float[5];


    private float minMin = 5.1f;
    private float maxMax = 48.8f;

    private float diff;
    
    
    bool canDamage = true;

    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        stp[0] = 11.67f;
        stp[1] = 21.67f;
        stp[2] = 31.67f;
        stp[3] = 41.67f;
        stp[4] = 48.8f;

        rootMaxHeight = stp[stage - 1];
        rootMinHeight = 5.1f;
    }

    // Update is called once per frame
    void Update()
    {
        pivotTransform.position = new Vector3(0, rootHeight, 0);
        spriteRenderer.material.SetFloat("_grow", Mathf.Lerp(spriteRenderer.material.GetFloat("_grow"), Scale(minMin, maxMax, rootHeight), Time.deltaTime));
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
    
    private static float Scale(float min, float max, float value)
    {
        return Mathf.Clamp(1 / (max - min) * (value - max) + 1, 0, 1);
    }
    
    public void DamageTree(float damage)
    {
        if (canDamage)
        {
            rootHeight -= damage;
            canDamage = false;
        }          
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        canvas.SetActive(true);
        PlayerItems items = other.GetComponent<PlayerItems>();
        switch (stage)
        {
           case 1:
               if (stage1[0] > 0)
               {
                   int s = stage1[0];
                   stage1[0] = Math.Max(stage1[0] -= items.tierraItems,0);
                   plitms.ChangeTierraItems(-s);
               }
               if (stage1[1] > 0)
               {
                   int s = stage1[1];
                   stage1[1] = Math.Max(stage1[1] -= items.waterItems,0);
                   plitms.ChangeWaterItems(-s);
               }
               if (stage1[2] > 0)
               {
                   int s = stage1[2];
                   stage1[2] = Math.Max(stage1[2] -= items.sunItems,0);
                   plitms.ChangeSunItems(-s);
               }
               if (stage1[3] > 0)
               {
                   int s = stage1[3];
                   stage1[3] = Math.Max(stage1[3] -= items.cacaItems,0);
                   plitms.ChangeCacaItems(-s);
               }
               if (stage1[4] > 0)
               {
                   int s = stage1[4];
                   stage1[4] = Math.Max(stage1[4] -= items.windItems,0);
                   plitms.ChangeWindItems(-s);
               }
               tierraText.text = $"{stage1[0]} / 6";
               waterText.text = $"{stage1[1]} / 0";
               sunText.text = $"{stage1[2]} / 0";
               cacaText.text = $"{stage1[3]} / 0";
               windText.text = $"{stage1[4]} / 0";
               var a = 5;
               foreach (int ap in stage1)
               {
                   a -= ap;
               }

               rootHeight = (a * 6.57f / 5) + rootMinHeight;
               
               foreach (int ap in stage1)
               {
                   if(ap > 0) return;
               }
               stage++;
               rootMinHeight = rootMaxHeight;
               rootMaxHeight = stp[stage - 1];
               tierraText.text = $"{stage2[0]} / 8";
               waterText.text = $"{stage2[1]} / 6";
               sunText.text = $"{stage2[2]} / 0";
               cacaText.text = $"{stage2[3]} / 0";
               windText.text = $"{stage2[4]} / 0";
               break;
           case 2:
               if (stage2[0] > 0)
               {
                   int s = stage2[0];
                   stage2[0] = Math.Max(stage2[0] -= items.tierraItems,0);
                   plitms.ChangeTierraItems(-s);
               }
               if (stage2[1] > 0)
               {
                   int s = stage2[1];
                   stage2[1] = Math.Max(stage2[1] -= items.waterItems,0);
                   plitms.ChangeWaterItems(-s);
               }
               if (stage2[2] > 0)
               {
                   int s = stage2[2];
                   stage2[2] = Math.Max(stage2[2] -= items.sunItems,0);
                   plitms.ChangeSunItems(-s);
               }
               if (stage2[3] > 0)
               {
                   int s = stage2[3];
                   stage2[3] = Math.Max(stage2[3] -= items.cacaItems,0);
                   plitms.ChangeCacaItems(-s);
               }
               if (stage2[4] > 0)
               {
                   int s = stage2[4];
                   stage2[4] = Math.Max(stage2[4] -= items.windItems,0);
                   plitms.ChangeWindItems(-s);
               }
               tierraText.text = $"{stage2[0]} / 8";
               waterText.text = $"{stage2[1]} / 6";
               sunText.text = $"{stage2[2]} / 0";
               cacaText.text = $"{stage2[3]} / 0";
               windText.text = $"{stage2[4]} / 0";
               a = 12;
               foreach (int ap in stage2)
               {
                   a -= ap;
               }

               rootHeight = (a * 10 / 12) + rootMinHeight;
               foreach (int ap in stage2)
               {
                   if(ap > 0) return;
               }
               tierraText.text = $"{stage3[0]} / 0";
               waterText.text = $"{stage3[1]} / 8";
               sunText.text = $"{stage3[2]} / 6";
               cacaText.text = $"{stage3[3]} / 0";
               windText.text = $"{stage3[4]} / 0";
               stage++;
               rootMinHeight = rootMaxHeight;
               rootMaxHeight = stp[stage - 1];
               break;
           case 3:
               if (stage3[0] > 0)
               {
                   int s = stage3[0];
                   stage3[0] = Math.Max(stage3[0] -= items.tierraItems,0);
                   plitms.ChangeTierraItems(-s);
               }
               if (stage3[1] > 0)
               {
                   int s = stage3[1];
                   stage3[1] = Math.Max(stage3[1] -= items.waterItems,0);
                   plitms.ChangeWaterItems(-s);
               }
               if (stage3[2] > 0)
               {
                   int s = stage3[2];
                   stage3[2] = Math.Max(stage3[2] -= items.sunItems,0);
                   plitms.ChangeSunItems(-s);
               }
               if (stage3[3] > 0)
               {
                   int s = stage3[3];
                   stage3[3] = Math.Max(stage3[3] -= items.cacaItems,0);
                   plitms.ChangeCacaItems(-s);
               }
               if (stage3[4] > 0)
               {
                   int s = stage3[4];
                   stage3[4] = Math.Max(stage3[4] -= items.windItems,0);
                   plitms.ChangeWindItems(-s);
               }
               tierraText.text = $"{stage3[0]} / 0";
               waterText.text = $"{stage3[1]} / 8";
               sunText.text = $"{stage3[2]} / 6";
               cacaText.text = $"{stage3[3]} / 0";
               windText.text = $"{stage3[4]} / 0";
               a = 12;
               foreach (int ap in stage3)
               {
                   a -= ap;
               }

               rootHeight = (a * 10 / 12)+ rootMinHeight;
               foreach (int ap in stage3)
               {
                   if(ap > 0) return;
               }
               stage++;
               rootMinHeight = rootMaxHeight;
               rootMaxHeight = stp[stage - 1];
               tierraText.text = $"{stage4[0]} / 0";
               waterText.text = $"{stage4[1]} / 0";
               sunText.text = $"{stage4[2]} / 8";
               cacaText.text = $"{stage4[3]} / 6";
               windText.text = $"{stage4[4]} / 0";
               break;
           case 4:
               if (stage4[0] > 0)
               {
                   int s = stage4[0];
                   stage4[0] = Math.Max(stage4[0] -= items.tierraItems,0);
                   plitms.ChangeTierraItems(-s);
               }
               if (stage4[1] > 0)
               {
                   int s = stage4[1];
                   stage4[1] = Math.Max(stage4[1] -= items.waterItems,0);
                   plitms.ChangeWaterItems(-s);
               }
               if (stage4[2] > 0)
               {
                   int s = stage4[2];
                   stage4[2] = Math.Max(stage4[2] -= items.sunItems,0);
                   plitms.ChangeSunItems(-s);
               }
               if (stage4[3] > 0)
               {
                   int s = stage4[3];
                   stage4[3] = Math.Max(stage4[3] -= items.cacaItems,0);
                   plitms.ChangeCacaItems(-s);
               }
               if (stage4[4] > 0)
               {
                   int s = stage4[4];
                   stage4[4] = Math.Max(stage4[4] -= items.windItems,0);
                   plitms.ChangeWindItems(-s);
               }
               tierraText.text = $"{stage4[0]} / 0";
               waterText.text = $"{stage4[1]} / 0";
               sunText.text = $"{stage4[2]} / 8";
               cacaText.text = $"{stage4[3]} / 6";
               windText.text = $"{stage4[4]} / 0";
               a = 12;
               foreach (int ap in stage4)
               {
                   a -= ap;
               }

               rootHeight = (a * 10 / 12) + rootMinHeight;
               foreach (int ap in stage4)
               {
                   if(ap > 0) return;
               }
               stage++;
               rootMinHeight = rootMaxHeight;
               rootMaxHeight = stp[stage - 1];
               tierraText.text = $"{stage5[0]} / 0";
               waterText.text = $"{stage5[1]} / 0";
               sunText.text = $"{stage5[2]} / 0";
               cacaText.text = $"{stage5[3]} / 0";
               windText.text = $"{stage5[4]} / 8";
               break;
           case 5:
               if (stage5[0] > 0)
               {
                   int s = stage5[0];
                   stage5[0] = Math.Max(stage5[0] -= items.tierraItems,0);
                   plitms.ChangeTierraItems(-s);
               }
               if (stage5[1] > 0)
               {
                   int s = stage5[1];
                   stage5[1] = Math.Max(stage5[1] -= items.waterItems,0);
                   plitms.ChangeWaterItems(-s);
               }
               if (stage5[2] > 0)
               {
                   int s = stage5[2];
                   stage5[2] = Math.Max(stage5[2] -= items.sunItems,0);
                   plitms.ChangeSunItems(-s);
               }
               if (stage5[3] > 0)
               {
                   int s = stage5[3];
                   stage5[3] = Math.Max(stage5[3] -= items.cacaItems,0);
                   plitms.ChangeCacaItems(-s);
               }
               if (stage5[4] > 0)
               {
                   int s = stage5[4];
                   stage5[4] = Math.Max(stage5[4] -= items.windItems,0);
                   plitms.ChangeWindItems(-s);
               }
               tierraText.text = $"{stage5[0]} / 0";
               waterText.text = $"{stage5[1]} / 0";
               sunText.text = $"{stage5[2]} / 0";
               cacaText.text = $"{stage5[3]} / 0";
               windText.text = $"{stage5[4]} / 8";
               a = 7;
               foreach (int ap in stage2)
               {
                   a -= ap;
               }

               rootHeight = (a * 10 / 7)+ rootMinHeight;
               foreach (int ap in stage5)
               {
                   if(ap > 0) return;
               }
               stage++;
               rootMinHeight = rootMaxHeight;
               rootMaxHeight = stp[stage - 1];
               break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canvas.SetActive(false);
    }
}
