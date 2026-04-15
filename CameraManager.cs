using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private float predkoscKamery = 5f;
    private float xMax;
    private float yMax;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WejscieKlawiatura();
        WejscieMyszy();
        Ogranicz();
    }

    private void WejscieKlawiatura()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * predkoscKamery * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * predkoscKamery * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * predkoscKamery * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * predkoscKamery * Time.deltaTime);
        }
    }

    private void WejscieMyszy()
    {
        int granica = 10;

        if(Input.mousePosition.y > Screen.height - granica)
        {
            transform.Translate(Vector3.up * predkoscKamery * Time.deltaTime);
        }
        if(Input.mousePosition.y < granica)
        {
            transform.Translate(Vector3.down * predkoscKamery * Time.deltaTime);
        }
        if(Input.mousePosition.x > Screen.width - granica)
        {
            transform.Translate(Vector3.right * predkoscKamery * Time.deltaTime);
        }
        if(Input.mousePosition.x < granica)
        {
            transform.Translate(Vector3.left * predkoscKamery * Time.deltaTime);
        }

    }

    public void UstawGranice(Vector3 ostatniKafelek)
    {
        Vector3 wp = Camera.main.ViewportToWorldPoint(new Vector3(1, 1));

        xMax = ostatniKafelek.x - wp.x;
        yMax = ostatniKafelek.y - wp.y;
    }
    
    private void Ogranicz()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0,xMax),
            Mathf.Clamp(transform.position.y, yMax, 0),-10);
    }
}
