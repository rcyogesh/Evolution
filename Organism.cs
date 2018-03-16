using System;
using System.Linq;

public class Organism
{
    const int size = 50;
    const int maxHeight = 500;

    static int[] terrain;

    static Organism()
    {
        terrain = CreateShape();
    }

    private static int[] CreateShape()
    {
        int[] shape = new int[size];
        Random random = new Random();
        for (int i = 0; i < size; i++)
        {
            shape[i] = random.Next(maxHeight);
        }
        return shape;
    }

    static double GetMatchIndex(Organism org)
    {
        var factor = org.GetMatchData().Average() / (double)maxHeight;
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

    public double MatchIndex { get; private set; }

    public int[] GetMatchData()
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
        MatchIndex = GetMatchIndex(this);
    }
    }


}