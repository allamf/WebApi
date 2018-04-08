using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions ;


using System.IO;


namespace TestFimakers
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;           
            Console.WriteLine(1 >> 2);
            Console.ReadKey();             
        }
        public IEnumerable<string> FilterList(List<string> strings)
        {
            return strings.Where(e => e.StartsWith("L")).OrderBy(x => x);
        }
        public static int Calc(int[] array, int n1, int n2)
        {

            int sum = 0;

            for (int i = n1; i <= n2; i++)
            {
                sum += array[i];

            }
            return sum;
        }
        public static string LocateUniverseFormula()
        {
            string[] fname = Directory.GetFiles("/tmp/documents", "*.*", SearchOption.AllDirectories);

            for (int i = 0; i < fname.Length; i++)
            {
                if (Path.GetFileName(fname[i]) == "universe-formula")
                {
                    return fname[i];
                }

            }

            return null;
        }
        static int closestToZero(int[] ints)
        {
            
            if (ints == null || ints.Length == 0)
            {
                return 0;
            }
            int output = int.MaxValue;

            for (int i = 0; i < ints.Length; i++)
            {
                if (ints[i] < output && ints[i] > 0)
                {
                    output = ints[i];
                }

            }

            return output;


        }


    }
}
