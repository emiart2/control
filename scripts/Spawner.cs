using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float czestotliwoscSpawna = 2f;    //tego nie bedziemy zmieniac
    float czasDoSpawna = 0;           //to bêdziemy liczyæ w ka¿dym odpaleniu funkcji/pêtli

    [System.Serializable]
    public class SkladnikFali
    {
        public GameObject prefabPotwora;

        public int ilosc;

        [System.NonSerialized] public int Stworzone = 0;
    }

     public SkladnikFali[] SkladnikiFali;

     void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Spawnowanie();
    }
    IEnumerator TestRoutine(float duration)
    {
        yield return new WaitForSeconds(duration);
    }

    void Spawnowanie()
    {
        czasDoSpawna -= Time.deltaTime;

        if (czasDoSpawna <= 0)
        {
            czasDoSpawna = czestotliwoscSpawna;

            bool potworStworzony = false;

            foreach(SkladnikFali sk in SkladnikiFali)
            {
                if(sk.Stworzone < sk.ilosc)
                {
                    Instantiate(sk.prefabPotwora, this.transform.position,
                        this.transform.rotation);

                    sk.Stworzone++;
                    potworStworzony = true;
                    break;
                }
            }
            if (!potworStworzony)
            {
                if (transform.parent.childCount > 1)
                {
                    StartCoroutine(TestRoutine(10f));
                    transform.parent.GetChild(1).gameObject.SetActive(true);
                }
                Destroy(gameObject);
            }
        }
    }
}
