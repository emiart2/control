using UnityEngine;

public class Kafelek : MonoBehaviour
{
    [SerializeField] public Punkt pozycja_na_siatce { get; set; }
    public int typ;
    private bool moznaBudowac = true;

    public Vector3 Srodek
    {
        get
        {
            return this.GetComponent<SpriteRenderer>().bounds.center;
        }
    }

    public void Setup(Punkt pozycja, int typ)
    {
        transform.SetParent(GameObject.FindGameObjectWithTag("Mapa").transform);
        this.pozycja_na_siatce = pozycja;
        this.typ = typ;
        moznaBudowac = (typ == 0);
    }

    private void OnMouseOver()
    {
        //Debug.Log("(" + pozycja_na_siatce.X + "," + pozycja_na_siatce.Y + ")");
        this.GetComponent<SpriteRenderer>().color = new Color(0.9f,0.8f,0.9f,0.8f);

        if (Input.GetMouseButtonDown(0) && moznaBudowac)
        {
            PostawWiezyczke();
        }
    }

    private void PostawWiezyczke()
    {
        print("postawiono jednostke");
        GameObject Wieza = GameObject.FindFirstObjectByType<GameManager>().Wieza;
        Instantiate(Wieza, this.Srodek, Quaternion.identity);
        moznaBudowac = false;
    }

    private void OnMouseExit()
    {
        this.GetComponent<SpriteRenderer>().color = Color.white;
    }

}
