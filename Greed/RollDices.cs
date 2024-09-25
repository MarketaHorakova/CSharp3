using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Greed
{
    public class RollDices
    {
        Random random = new Random();
        int[] arrayNumbers = new int[5];

        public string ToRoll()
        {
            for (int i = 0; i < arrayNumbers.Length; i++)
            {
                arrayNumbers[i] = random.Next(1, 7);
            }

            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            foreach (int number in arrayNumbers)
            {
                builder.Append(number);

            }

            return builder.ToString();

        }

        public string ToCalculate()
        {
            string result = "Not yet";
            int resultNumber = 0;
            if (arrayNumbers[0] == 0)
            {
                result = "Nothing to calculate. Roll at first!";
            }

            switch (arrayNumbers)
            {
                case [0, 0, 0, 0, 0]:
                    result = "Nothing to calculate. Roll at first!";
                    break;
                case []:
                    resultNumber += 1000;
                    break;

            }

            return "Win points: " + resultNumber.ToString();
        }

    }
}
