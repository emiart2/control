using System;
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
    public override int GetHashCode()
    {
        //zamiast domyœlnego, po³¹czenie hashcode dla x i y

        return HashCode.Combine(X, Y);
    }

    public override bool Equals(object obj)
    {
        //ustalamy jak porównujemy dwa punkty 

        if(obj is Punkt other)
        {
            return X == other.X && Y == other.Y;
        }
        return false;
    }

}
