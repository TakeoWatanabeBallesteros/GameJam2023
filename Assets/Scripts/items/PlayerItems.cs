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

    public void ChangeSunItems(int valor)
    {
        sunItems += valor;
        sunText.text = sunItems.ToString();
    }
    public void ChangeWindItems(int valor)
    {
        windItems += valor;
        windText.text = windItems.ToString();
    }
    public void ChangeWaterItems(int valor)
    {
        waterItems += valor;
        waterText.text = waterItems.ToString();
    }
    public void ChangeCacaItems(int valor)
    {
        cacaItems += valor;
        cacaText.text = cacaItems.ToString();
    }
    public void ChangeTierraItems(int valor)
    {
        tierraItems += valor;
        tierraText.text = tierraItems.ToString();
    }
}
