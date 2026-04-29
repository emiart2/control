using UnityEngine;

public class Celowanie : MonoBehaviour
{
    private Przeciwnik cel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Potwor")
        {
            cel = collision.GetComponent<Przeciwnik>();
            print(cel);
        }
    }
}
