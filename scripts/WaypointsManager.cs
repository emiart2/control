using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsManager : MonoBehaviour
{
    public List<Vector3> punkty_kontrolne { get; private set; }

    private LevelManager lm;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ZnajdzPunkty()
    {
        punkty_kontrolne = new List<Vector3>();
        lm = FindFirstObjectByType<LevelManager>();

        int x_aktualny = 5;
        int y_aktualny = 0;

        int x_poprzedni = -1;
        int y_poprzedni = -1;

        const int GORA = 0;
        const int PRAWA = 1;
        const int DOL = 2;
        const int LEWA = 3;

        const int SCIEZKA = 0;

        int mapaX = lm.mapa_szerokosc;
        int mapaY = lm.mapa_wysokosc;

        Punkt[] sasiedzi = new Punkt[4];

        bool znaleziony = true;

        while (znaleziony)
        {
            znaleziony = false;

            punkty_kontrolne.Add(lm.Kafelki[new Punkt(x_aktualny, y_aktualny)].Srodek);

            //zerujemy tablice
            for (int i=0; i<4; i++)
            {
                sasiedzi[i] = new Punkt(-1,-1);
            }

            if(y_aktualny < mapaY)
            {
                sasiedzi[GORA] = new Punkt(x_aktualny, y_aktualny + 1);
            }
            if (x_aktualny < mapaX)
            {
                sasiedzi[PRAWA] = new Punkt(x_aktualny+1, y_aktualny);
            }
            if (y_aktualny > 0)
            {
                sasiedzi[DOL] = new Punkt(x_aktualny, y_aktualny - 1);
            }
            if ( x_aktualny > 0)
            {
                sasiedzi[LEWA] = new Punkt(x_aktualny - 1, y_aktualny);
            }

            for(int i = 0; i<4; i++)
            {
                if (sasiedzi[i].X != -1)
                {
                    if (lm.Kafelki[sasiedzi[i]].typ == SCIEZKA)
                    {
                        if (sasiedzi[i].X == x_poprzedni && sasiedzi[i].Y == y_poprzedni)
                        {
                            continue;
                        }
                        x_poprzedni = x_aktualny;
                        y_poprzedni = y_aktualny;

                        x_aktualny = sasiedzi[i].X;
                        y_aktualny = sasiedzi[i].Y;

                        znaleziony = true;

                        break;
                        
                    }



                }
            }

        }

    } 
}
