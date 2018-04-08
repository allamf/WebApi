using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace codingGame
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int i = 0, k = 0, x1 = 0, x2 = -1, x3 = -1;
            int j = 0, y1 = 0, y2 = -1, y3 = -1;
            int r = 0;
            // à initialiser

            // x axis

           // Console.WriteLine("entrez une valeur width");
            int width = int.Parse(Console.ReadLine());

            if (width < 0 || width > 30)
                throw new Exception("la valeur de width doit etre > 0 et inferieur 30") ;

           // Console.WriteLine("entrez une valeur height");
            int height = int.Parse(Console.ReadLine());          

            if (height < 0 || height > 30)
                throw new Exception("la valeur de width doit etre > 0 et inferieur 30");



            string[] tab = new string[height];

            for (k = 0; k < height; k++)
            {
               // Console.WriteLine("entrez une valeur line");
                string line = Console.ReadLine();
                if (!line.Length.Equals(width))
                {
                    throw new Exception("la taille  ne correspond pas ");
                }
                tab[k] = line;               

            }

            // nombre de lignes
            for (i = 0; i < height; i++)
            {
                // pour chaque ligne
                for (j = 0; j < width; j++)
                {
                    string node = tab[i].ElementAt(j) + "";

                    x2 = -1; y2 = -1;
                    x3 = -1; y3 = -1;

                    // if node 
                    if (node.Equals("0"))
                    {
                        x1 = j;
                        y1 = i;

                        // get right neighbour

                        for (r = j + 1; r < width; r++)
                        {
                            node = tab[i].ElementAt(r) + "";

                            if (node.Equals("0"))
                            {
                                x2 = r;
                                y2 = i;
                                break;
                            }
                        }

                        // get bottom neighbour

                          for (int b = i+1 ; b < height; b++)
                            {
                                node = tab[b].ElementAt(j) + "";

                                if (node.Equals("0"))
                                {
                                    x3 = j;
                                    y3 = b;
                                    break;
                                }
                            }                       

                        Console.WriteLine("{0} {1} {2} {3} {4} {5}", x1, y1, x2, y2, x3, y3);
                       // Console.ReadKey();
                    }
                }
            }
        }

        public static int fact(int n)
        {
            int result = 1;

            for (int i =1; i <= n; i++)
            {
                result *= n ;
            }
            return result;

        }

        // n = 4         
        //  4 *fac(3) =4 *3 *fac(2) = 4*3*2*fac(1)
        public static int fac(int n)
        {
            if (n == 1) return 1;
            return n * fac(n - 1);
        }

        public static int fib (int n)
        {
            if (n == 1) return 1;

            return fib(n - 1) + fib(n - 2);


        }

       
        



       }

    
}
