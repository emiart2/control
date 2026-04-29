using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject wiezaPrefab;

    public GameObject Wieza
    {
        get
        {
            return wiezaPrefab;
        }
    }
}
