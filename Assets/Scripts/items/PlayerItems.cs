using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerItems : MonoBehaviour
{
    public int sunItems = 0;
    public int windItems = 0;
    public int cacaItems = 0;
    public int waterItems = 0;
    public int tierraItems = 0;

    [SerializeField] TextMeshProUGUI sunText;
    [SerializeField] TextMeshProUGUI windText;
    [SerializeField] TextMeshProUGUI cacaText;
    [SerializeField] TextMeshProUGUI waterText;
    [SerializeField] TextMeshProUGUI tierraText;

    public float limitItem;

    public void ChangeSunItems(int valor)
    {
        sunItems += valor;
        if (sunItems < 0) sunItems = 0;
        sunText.text = sunItems.ToString();
    }
    public void ChangeWindItems(int valor)
    {
        windItems += valor;
        if (windItems < 0) windItems = 0;
        windText.text = windItems.ToString();
    }
    public void ChangeWaterItems(int valor)
    {
        waterItems += valor;
        if (waterItems < 0) waterItems = 0;
        waterText.text = waterItems.ToString();
    }
    public void ChangeCacaItems(int valor)
    {
        cacaItems += valor;
        if (cacaItems < 0) cacaItems = 0;
        cacaText.text = cacaItems.ToString();
    }
    public void ChangeTierraItems(int valor)
    {
        tierraItems += valor;
        if (tierraItems < 0) tierraItems = 0;
        tierraText.text = tierraItems.ToString();
    }
    public void SinLimite()
    {
        limitItem = 9999999999999999;
    }
}
