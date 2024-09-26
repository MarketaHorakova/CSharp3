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
        int oneCounter = 0;
        int twoCounter = 0;
        int threeCounter = 0;
        int fourCounter = 0;
        int fiveCounter = 0;
        int sixCounter = 0;

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
                switch (number)
                {
                    case 1:
                        oneCounter++;
                        break;
                    case 2:
                        twoCounter++;
                        break;
                    case 3:
                        threeCounter++;
                        break;
                    case 4:
                        fourCounter++;
                        break;
                    case 5:
                        fiveCounter++;
                        break;
                    case 6:
                        sixCounter++;
                        break;
                }
            }

            return builder.ToString();
        }

        public string ToCalculate()
        {
            string result = "Nothing rolled";
            int resultNumber = 0;
            if (arrayNumbers[0] == 0)
            {
                result = "Nothing to calculate. Roll at first!";
            }

            switch (oneCounter)
            {
                case 1:
                    resultNumber += 100;
                    break;
                case 2:
                    resultNumber += 200;
                    break;
                case 3:
                    resultNumber += 1000;
                    break;
                case 4:
                    resultNumber += 1100;
                    break;
                case 5:
                    resultNumber += 1200;
                    break;
            }

            if (twoCounter > 2)
            {
                resultNumber += 200;
            }
            if (threeCounter > 2)
            {
                resultNumber += 300;
            }
            if (fourCounter > 2)
            {
                resultNumber += 400;
            }
            switch (fiveCounter)
            {
                case 1:
                    resultNumber += 50;
                    break;
                case 2:
                    resultNumber += 100;
                    break;
                case 3:
                    resultNumber += 500;
                    break;
                case 4:
                    resultNumber += 550;
                    break;
                case 5:
                    resultNumber += 600;
                    break;
            }


            if (sixCounter > 2)
            {
                resultNumber += 600;
            }
            return "Win points: " + resultNumber.ToString();

        }

    }
}
