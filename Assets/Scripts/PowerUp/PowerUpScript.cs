using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    [Header("Radar")]
    [SerializeField] spawnEnemy enemy;
    [Header("SinFondo")]
    [SerializeField] PlayerItems playerItem;

    [SerializeField] private PlayerScript playerScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Radar()
    {
        //enemy.hasRadar = true;
        GameObject.FindGameObjectWithTag("decision3").GetComponent<PowerUpController>().DestroyDesicion();
    }
    public void TP()
    {
        GameObject.FindGameObjectWithTag("decision4").GetComponent<PowerUpController>().DestroyDesicion();
    }
    public void AyudaDeDemeter()
    {
        GameObject.FindGameObjectWithTag("decision1").GetComponent<PowerUpController>().DestroyDesicion();

        List<GameObject> cacas = new List<GameObject>(GameObject.FindGameObjectsWithTag("getCaca"));
        List<GameObject> tierras = new List<GameObject>(GameObject.FindGameObjectsWithTag("getTierra"));
        List<GameObject> aguas = new List<GameObject>(GameObject.FindGameObjectsWithTag("getWater"));
        List<GameObject> winds = new List<GameObject>(GameObject.FindGameObjectsWithTag("getWind"));
        List<GameObject> suns = new List<GameObject>(GameObject.FindGameObjectsWithTag("getSun"));

        foreach (var item in cacas)
        {
            item.GetComponent<GetCaca>().DoubleItem();
        }
        foreach (var item in tierras)
        {
            item.GetComponent<GetTierra>().DoubleItem();
        }
        foreach (var item in aguas)
        {
            item.GetComponent<GetWater>().DoubleItem();
        }
        foreach (var item in winds)
        {
            item.GetComponent<GetWind>().DoubleItem();
        }
        foreach (var item in suns)
        {
            item.GetComponent<GetSun>().DoubleItem();
        }
    }
    public void GuantesDeJack()
    {
        GameObject.FindGameObjectWithTag("decision4").GetComponent<PowerUpController>().DestroyDesicion();
    }
    public void SinFondo()
    {
        playerItem.SinLimite();
        GameObject.FindGameObjectWithTag("decision2").GetComponent<PowerUpController>().DestroyDesicion();
    }
    public void Humilde()
    {
        GameObject.FindGameObjectWithTag("decision1").GetComponent<PowerUpController>().DestroyDesicion();


    }
    public void BambasErizo()
    {
        GameObject.FindGameObjectWithTag("decision2").GetComponent<PowerUpController>().DestroyDesicion();
    }
    public void Espantabichos()
    {
        enemy.EspantabichosPowerUp();
        GameObject.FindGameObjectWithTag("decision3").GetComponent<PowerUpController>().DestroyDesicion();
    }
}
