using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Test.Invivoo
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    // le nombre de tours à jouer
        //    int numbOfTurn = Int32.Parse(Console.ReadLine());

        //    // initialize les coordonnées du player
        //    int xp = Int32.Parse(Console.ReadLine());
        //    int yp = Int32.Parse(Console.ReadLine());
        //    Enemy player = new Enemy("player", xp, xp);

        //    // initialize la distance à partir de laquelle
        //    // on peut considerer l'enemy est proche pour l'eliminer
        //    int x = Int32.Parse(Console.ReadLine());
        //    int y = Int32.Parse(Console.ReadLine());
        //    Distance closestDist = new Distance(x, y);

        //    // initialize le nombre d'enemis
        //    int numbOfEnemy = Int32.Parse(Console.ReadLine());

        //    // initialise les coordonées des enemis
        //    List<Enemy> enemis = new List<Enemy>();

        //    for (int i = 0; i < numbOfEnemy; i++)
        //    { 
        //        enemis.Add(new Enemy("player"+i, i, i+1));
        //    }

        //    // create game
        //    Game game = new Game(numbOfTurn, player, closestDist, enemis);

        //    // start game
        //    game.destroyClosestEnemy();

        //}

        static void Main(string[] args)
        {
            int[] tab = new int[] { 1, 6, 6, 9 };
            int greatest = getGreatest(tab);
            int smallest = getSmallest(tab);

            string input = "je vais a l'ecole";
            String toto = Regex.Replace(input, @"[aAiIoOuUeE\s]", "");



        }

        public static string Sum(params string[] numbers)
        {
            decimal total = 0;

            foreach (string number in numbers)
            {
                total = total + decimal.Parse(number);
            }

            return total.ToString();
        }

        // * une suite de , $ termine par
        // ^ ça commence par a ou b ... dans []
        public static bool findPattern(string input)
        {
            if (String.IsNullOrEmpty(input))
                return true;
            else
            {
                if (input.Contains("[()]") || input.Contains("()"))
                    return true;
                else
                    return false;
            }
        }

        public static bool isAlphabet(string input)
        {
            bool matches = Regex.IsMatch(input, @"^[a-zA-Z]*$");
            return matches;

        }

        public static bool isNumeric(string input)
        {
            bool matches = Regex.IsMatch(input, @"^[0-9]*$");
            return matches;
        }

        public static bool isAlphaNumeric(string input)
        {
            bool matches = Regex.IsMatch(input, @"^[a-zA-Z0-9]*$");
            return matches;

        }

        public static int getGreatest(int[] tab)


        {
            int greatest = int.MinValue;

            for (int i = 0; i < tab.Length; i++)
            {
                if (tab[i] > greatest)
                {
                    greatest = tab[i];
                }

            }

            return greatest;

        }

        public static int getSmallest(int[] tab)
        {
            int smallest = int.MaxValue;

            for (int i = 0; i < tab.Length; i++)
            {
                if (tab[i] < smallest)
                {
                    smallest = tab[i];
                }

            }

            return smallest;

        }

        //static int substrings(String input)
        //{
        //    String output = input.replaceAll("\\s", "");
        //    Set<String> chs = new HashSet<String>();
        //    while (output.length() != 0 && output.length() > 4)
        //    {
        //        chs.add(output.substring(0, 4));
        //        output = output.substring(4, output.length() - 1);
        //    }
        //    return chs.size();
        //}
        static bool isPrimeCube(int n)
        {
            for (int i = 2; i <= n; i++)
            {
                bool isPrime = true;
                for (int j = 2; j <= n; j++)
                {
                    if (i != j && i % j == 0)
                    {
                        isPrime = false;
                    }
                }
                if (isPrime)
                {
                    if (Math.Pow(i, 3) == n)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public String removeVowels(String input)
        {
            return Regex.Replace(input, @"[iIoOuUaAeE\s]", "");
        }

        public class ThreadSafe
        {
            private static int count;
            private static object syncObj = new object();

            public static int Increment(int count)
            {
                lock (syncObj)
                {
                    count = count + 1;
                }
                return count;
            }

        }

        public class SingletonThreadSafe
        {
            // thread safe
            SingletonThreadSafe()
            {

            }

            private static readonly object objSync = new object();
            private static SingletonThreadSafe instance = null;
            public static SingletonThreadSafe getInstance()
            {
                lock (objSync)
                {
                    if (instance == null)
                    {
                        instance = new SingletonThreadSafe();
                    }
                    return instance;
                }
            }
        }

        public class Enemy
        {
            public string name { get; set; }
            public Distance dist { get; set; }

            public Enemy(string name, int x, int y)
            {
                this.name = name;
                this.dist = new Distance(x, y);
            }
        }

        public class Distance
        {
            public int x { get; set; }
            public int y { get; set; }

            public Distance(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public class Game
        {
            public int numbOfTurn { get; set; }
            List<Enemy> numbOfEnemies { get; set; }
            Enemy player { get; set; }
            public Distance closestDist { get; set; }

            public Game(int numbOfTurn, Enemy player, Distance closestDist, List<Enemy> numbOfEnemies)
            {
                this.numbOfTurn = numbOfTurn;
                this.numbOfEnemies = numbOfEnemies;
                this.player = player;
                this.closestDist = closestDist;
            }


            public void destroyClosestEnemy()
            {
                List<Enemy> closest = new List<Enemy>();
                int compteur = 0;

                for (int i = 0; i < numbOfTurn; i++)
                {
                    // get two closest enemy
                    foreach (Enemy enemy in numbOfEnemies)
                    {
                        while (compteur < 2)
                        {
                            if (((enemy.dist.x - player.dist.x) == closestDist.x) && ((enemy.dist.y - player.dist.y) == closestDist.y))
                            {
                                closest.Add(enemy);
                                compteur++;
                            }

                        }
                    }
                    // print name of enemy

                    foreach (Enemy e in closest)
                    {
                        Console.WriteLine("Enemy {0} is detroyed his game is over", e.name);
                    }

                    Console.WriteLine("game of turn {0} is end", i);
                }

            }
        }

    }
}

