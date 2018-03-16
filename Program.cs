using System;

namespace evolution
{
    class Program
    {
        static void Main(string[] args)
        {
            Organism org = new Organism();
            double matchIndex;
            int i=0, j=0;
            do
            {
                matchIndex = org.MatchIndex;
                var origShape = org.Shape;
                Console.WriteLine("Match index is {0}", matchIndex);
                int[] newShape = origShape.Clone() as int[];
                Reshape(newShape);
                i++;
                var clone = new Organism(newShape);
                if(Math.Abs(clone.MatchIndex)>Math.Abs(org.MatchIndex))
                {
                    Console.WriteLine("Rejected");
                    org.Shape = origShape;
                    j++;
                }
                else{
                    org = clone;
                    var matchData = org.GetMatchData();
                    foreach (var item in matchData)
                    {
                        //Console.Write("{0},", item);
                    }
                    Console.WriteLine();
                }
            }
            while(org.MatchIndex > 1e-10);

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
