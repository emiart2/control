using UnityEditor.Search;
using UnityEngine;
using System.Collections.Generic;

public class Celowanie : MonoBehaviour
{
    private Przeciwnik cel;
    private Queue<Przeciwnik> cele = new Queue<Przeciwnik>();
    [SerializeField] private GameObject prefabPocisku;

    private float odstep = 1f;
    private float pozostaly_czas = 0f;

    private void Update()
    {
        Atakuj();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Potwor")
        {
            Przeciwnik kolejkowicz = collision.GetComponent<Przeciwnik>();
            cele.Enqueue(kolejkowicz);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Potwor")
        {
            cel = null;
        }
    }

    private void Atakuj()
    {
        if(cel == null && cele.Count > 0)
        {
            cel = cele.Dequeue();
        }

        pozostaly_czas -= Time.deltaTime;

        if(pozostaly_czas <= 0)
        {
            pozostaly_czas = odstep;
            Strzelaj();
        }
  
    }
    private void Strzelaj()
    {
        //stworzenie i ustawienie pocisku
        if(cel != null && cel.Zyje)
        {
            print("Atakuje " + cel);
            GameObject pocisk = Instantiate(prefabPocisku,
                this.transform.position, Quaternion.identity);

            pocisk.GetComponent<Pocisk>().UstawCel(cel);
        }
    }
}
