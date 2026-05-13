using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Pocisk : MonoBehaviour
{
    private Przeciwnik mojCel;
    [SerializeField] private float predkosc = 5f;
    float obrazenia = 5f;
     void Start()
    {
        
    }

    void Update()
    {
        Ruch();
    }

    private void Ruch()
    {
        if (mojCel != null && mojCel.Zyje)
        {
            Vector3 kierunek = mojCel.transform.position - this.transform.position;

            float dystans = predkosc * Time.deltaTime;

            transform.Translate(kierunek.normalized * dystans);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    public void UstawCel(Przeciwnik cel)
    {
        mojCel = cel;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Potwor")
        {
            collision.GetComponent<Przeciwnik>().Obrazenia(obrazenia);
            Destroy(gameObject);
        }
    }
}
