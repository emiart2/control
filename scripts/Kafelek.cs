using UnityEngine;

public class Kafelek : MonoBehaviour
{
    [SerializeField] public Punkt pozycja_na_siatce { get; set; }
    public int typ;

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
    }

    private void OnMouseOver()
    {
        Debug.Log("(" + pozycja_na_siatce.X + "," + pozycja_na_siatce.Y + ")");
        this.GetComponent<SpriteRenderer>().color = new Color(0.9f,0.8f,0.9f,0.8f);
    }

    private void OnMouseExit()
    {
        this.GetComponent<SpriteRenderer>().color = Color.white;
    }

}
