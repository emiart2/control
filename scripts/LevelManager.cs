using UnityEngine;
using System;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject[] kafelki;
    [SerializeField] CameraManager cameraManager;
    public Dictionary<Punkt,Kafelek> Kafelki { get; set; }

    public int mapa_wysokosc;
    public int mapa_szerokosc;


    void Start()
    {
        StworzPoziom();
    }

    void Update()
    {
        
    }
    private void StworzPoziom()
    {
        Kafelki = new Dictionary<Punkt, Kafelek>();
        string[] daneMapy = WczytajPoziom();
        float rozmiar_k = RozmiarKafelka();

        Vector3 start_kafelek = new Vector3(-6.24f, 4.37f, 0);

        mapa_wysokosc = daneMapy[0].ToCharArray().Length;
        mapa_szerokosc = daneMapy.Length;

        Vector3 pozycja = new Vector3(0, 0);

        for(int i=0; i<mapa_szerokosc; i++)
        {
            //zapisac napis
            char[] noweKafelki = daneMapy[i].ToCharArray();

            for(int j=0; j<mapa_wysokosc; j++)
            {
                //wyciagnac cyferke
                Punkt indeksy = new Punkt(i, j);

                pozycja = start_kafelek + new Vector3(rozmiar_k * j, rozmiar_k * -i, 0);

                UmieszczanieKafelka(pozycja, noweKafelki[j], indeksy);
            }
        }
        pozycja += new Vector3(rozmiar_k, rozmiar_k);
        cameraManager.UstawGranice(pozycja);
    }
    private void UmieszczanieKafelka(Vector3 pozycja, char rodzaj_kafelka, Punkt indeksy)
    {
        int numer_kafelka = (int)System.Char.GetNumericValue(rodzaj_kafelka);

        GameObject nowy_kafelek = Instantiate(kafelki[numer_kafelka]);

        nowy_kafelek.GetComponent<Kafelek>().Setup(indeksy, numer_kafelka);

        nowy_kafelek.transform.position = pozycja;

        Kafelki.Add(indeksy, nowy_kafelek.GetComponent<Kafelek>());

    }

    public float RozmiarKafelka()
    {
        return kafelki[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x; 
    }

    private string[] WczytajPoziom()
    {
        TextAsset wczytaneDane = Resources.Load("level1") as TextAsset;
        
        string dane = wczytaneDane.text.Replace(Environment.NewLine, string.Empty);
        
        return dane.Split(',');
    }
}
