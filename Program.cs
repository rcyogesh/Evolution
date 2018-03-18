using System;

namespace evolution
{
    class Program
    {
        static void Main(string[] args)
        {
            Organism org = new Organism();
            int[] terrain = Organism.CreateShape();
            double matchIndex;
            int i=0, j=0;
            do
            {
                matchIndex = org.GetMatchIndex(terrain);
                var origShape = org.Shape;
                Console.WriteLine("Match index is {0}", matchIndex);
                int[] newShape = origShape.Clone() as int[];
                Reshape(newShape);
                i++;
                var clone = new Organism(newShape);
                if(clone.GetMatchIndex(terrain)>matchIndex)
                {
                    Console.WriteLine("Rejected");
                    org.Shape = origShape;
                    j++;
                }
                else{
                    org = clone;
                    var matchData = org.GetMatchData(terrain);
                    foreach (var item in matchData)
                    {
                        Console.Write("{0},", item);
                    }
                    Console.WriteLine();
                }
            }
            while(org.GetMatchIndex(terrain) > 5);

            Console.WriteLine("{0} attempts, {1} rejections", i, j);
        }

        private static void Reshape(int[] newShape)
        {
            Random random = new Random();
            for (int j = 0; j < newShape.Length; j++)
            {
                var fact = random.NextDouble();
                int add = 0;
                if (fact > 0.666)
                {
                    add = 1;
                }
                else if (fact < 0.333)
                {
                    add = -1;
                }
                newShape[j] += add;
            }
        }
    }
}
