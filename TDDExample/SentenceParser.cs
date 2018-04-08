using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDExample
{
    public class SentenceParser
    {
        public int GetNoofWordsInString(string str)
        {
          return str.Trim().Split(' ').Length;

        }

        public string FizzBuz (int x)
        {
            if (x % 3 == 0 && x % 5 == 0)
                return "FizzBuz";
            if (x % 3 == 0)
                return "Fizz";
            if (x % 5 == 0)
                return "Buzz";
            return "";
        }

        public bool isCube(int x)
        {
            int racineCube = Convert.ToInt32(Math.Pow(x, 1.0 / 3.0));

            for (int i = 0; i < racineCube; i++)
            {
                if (Math.Pow(i,3) == x)
                {
                    return true;
                }

            }

            return false;

        }

    }
}
