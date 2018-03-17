using System;
using System.Linq;

public class Organism
{
    const int size = 50;
    const int maxHeight = 500;

    public static int[] CreateShape()
    {
        int[] shape = new int[size];
        Random random = new Random();
        for (int i = 0; i < size; i++)
        {
            shape[i] = random.Next(maxHeight);
        }
        return shape;
    }

    static double GetMatchIndex(Organism org, int[] terrain)
    {
        var factor = org.GetMatchData(terrain).Average() / (double)maxHeight;
        return Math.Abs(1 - factor) * 10000.0;
    }

    int[] shape;

    public Organism()
    :this(CreateShape())
    { }

    public Organism(int[] shape)
    {
        this.Shape = shape;
    }

    public int[] GetMatchData(int[] terrain)
    {
        int[] total = new int[size];
        for (int i = 0; i < size; i++)
        {
            total[i] = shape[i] + terrain[i];
        }
        return total;
    }

    public int[] Shape {
        get{
        return shape;
    } set{
        shape = value;
    }
    }

    public double GetMatchIndex(int[] terrain)
    {
        return GetMatchIndex(this, terrain);
    }
}