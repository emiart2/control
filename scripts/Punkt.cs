using UnityEngine;

public struct Punkt
{
    [SerializeField]
    public int X { get;  set;}
    public int Y { get; set; }

    public Punkt(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

}
