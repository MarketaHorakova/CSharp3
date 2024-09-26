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
        int[] arrayNumbers = new int[6];
        int oneCounter = 0;
        int twoCounter = 0;
        int threeCounter = 0;
        int fourCounter = 0;
        int fiveCounter = 0;
        int sixCounter = 0;

        public string ToRoll()
        {
            oneCounter = 0;
            twoCounter = 0;
            threeCounter = 0;
            fourCounter = 0;
            fiveCounter = 0;
            sixCounter = 0;
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
            int resultNumber = 0;

            if (TreePairs(oneCounter,twoCounter, threeCounter, fourCounter, fiveCounter, sixCounter))
            {
                resultNumber = 800;
            }
            else if (oneCounter == 1 && twoCounter == 1 && threeCounter == 1 && fourCounter == 1 && fiveCounter == 1 && sixCounter == 1)
            {
                resultNumber = 1200;
            }
            else
            {
                resultNumber += (Counter(oneCounter, 1000) + OneFiveCounter(oneCounter, 100));
                resultNumber += Counter(twoCounter, 200);
                resultNumber += Counter(threeCounter, 300);
                resultNumber += Counter(fourCounter, 400);
                resultNumber += (Counter(fiveCounter, 500) + OneFiveCounter(fiveCounter, 50));
                resultNumber += Counter(sixCounter, 600);

            }
            return "Win points: " + resultNumber.ToString();

        }

        private int Counter(int rolledDiceNumber, int dicePointValue)
        {
            int counterNumber = 0;
            switch (rolledDiceNumber)
            {
                case 6:
                    counterNumber += 8 * dicePointValue;
                    break;
                case 5:
                    counterNumber += 4 * dicePointValue;
                    break;
                case 4:
                    counterNumber += 2 * dicePointValue;
                    break;
                case 3:
                    counterNumber += 1 * dicePointValue;
                    break;
            }
            return counterNumber;
        }

        private int OneFiveCounter(int rolledDiceNumber, int dicePointValue)
        {
            int counterNumber = 0;
            switch (rolledDiceNumber)
            {
                case 1:
                    counterNumber += dicePointValue;
                    break;
                case 2:
                    counterNumber += 2*dicePointValue;
                    break;
            }
            return counterNumber;
        }

        private bool TreePairs(int one, int two, int three, int four, int five, int six)
        {
            int pairNumber = 0;
            if (one == 2)
            {
                pairNumber += 1;
            }
            if (two == 2)
            {
                pairNumber += 1;
            }
            if (three == 2)
            {
                pairNumber += 1;
            }
            if (four == 2)
            {
                pairNumber += 1;
            }
            if (five == 2)
            {
                pairNumber += 1;
            }
            if (six == 2)
            {
                pairNumber += 1;
            }
            return (pairNumber == 3);
        }

    }
}
