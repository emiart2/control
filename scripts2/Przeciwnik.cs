using UnityEngine;

public class Przeciwnik : MonoBehaviour
{
    private WaypointsManager wm;
    private float predkosc = 5f;

    private int obecny_punkt = 0;
    void Start()
    {
        wm = FindFirstObjectByType< WaypointsManager > ();
    }

    // Update is called once per frame
    void Update()
    {
        Ruch();
    }

    private void Ruch()
    {
        Vector3 kierunek = wm.punkty_kontrolne[obecny_punkt] - this.transform.position;

        float dystans = predkosc * Time.deltaTime;

        if(kierunek.magnitude <= dystans)
        {
            if(obecny_punkt == wm.punkty_kontrolne.Count - 1)
            {
                Destroy(gameObject);
            }
            else
            {
                obecny_punkt++;
            }
        }
        transform.Translate(kierunek.normalized * dystans);
    }
}
