using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    [Header("Radar")]
    [SerializeField] spawnEnemy enemy;
    [Header("SinFondo")]
    [SerializeField] PlayerItems playerItem;
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
        enemy.hasRadar = true;
    }
    public void TP()
    {

    }
    public void AyudaDeDemeter()
    {
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

    }
    public void SinFondo()
    {
        playerItem.SinLimite();
    }
    public void Humilde()
    {

    }
    public void BambasErizo()
    {

    }
    public void Espantabichos()
    {
        enemy.EspantabichosPowerUp();
    }
    void ClockButton(GameObject b1,GameObject b2,GameObject desicion)
    {
        b1.SetActive(false);
        b2.SetActive(false);
        desicion.GetComponent<Animator>().SetTrigger("dissapear");
        StartCoroutine(DestroyDesicion(desicion));
    }
    IEnumerator DestroyDesicion(GameObject desicion)
    {
        yield return new WaitForSeconds(1f);
        Destroy(desicion);
    }
}
