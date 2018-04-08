using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestQuanteam
{
   public class Program
    {
        static void Main(string[] args)
        {
            int[] cards = new int[] { 1, 2, 7, 3, 4, 5, 6, 9, 8, 12, 11,10};
            List<Player> players = distrubutedCard(cards, 3);
            Console.WriteLine();          

        }


        public static List<Player> distrubutedCard(int[] cards, int nbPlayers)
        {
            Array.Sort(cards);

            int nbCardsForPlayer = cards.Length / nbPlayers;

            List<Player> players = new List<Player>();

            int c = 0;

            for (int i = 0; i < nbPlayers; i++)
            {

                Player player = new Player(nbCardsForPlayer);

                for (int card = 0; card < player.cards.Length; card++)
                {
                    player.cards[card] = cards[c];
                    c += nbPlayers;
                }
                players.Add(player);
                c = i + 1;


            }
            // 0 , 4 , 8 ,12

            //foreach (Player player in players)
            //{
            //int c = 0;

            //while (c <= cards.Length)
            //{
            //    for (int card = 0; card < player.cards.Length; card++)
            //    {
            //        player.cards[card] = cards[c];
            //        c += nbCardsForPlayer;
            //    }
            //}

            //c++;

            //}

            return players;

        }

    }

    public class Player
    {
       public int[] cards {get; set;}

       public Player(int nbCards)
        {
            this.cards = new int [nbCards];

        }
        
    }

}



