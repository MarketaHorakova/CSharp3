using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Greed
{
    public class RollDice
    {
        //Celkovo super práca, vidno, že si sa nad tým zamyslela, systematicky si si to rozdelila na menšie problémy a potom postupne vyriešila. Mňa to teda napadlo úplne inak :D skvelo zvládnuté zadanie
        //Tie komentáre nižšie sú len také rady k lepším praktikám, ktoré sa ti môžu zíjsť do budúcnosti
        //Jedna veľká vec, ktorá je asi nad rámec tohto kurzu, je škálovateľnosť tohto kódu. Keby ti niekto povedal, že teraz prerob túto hru na kocku s 20 stranami, tak by to bolo veľmi veľmi bolestivé to prepisovať. Ale postupne sa naučíš myslieť viac genericky, uvidíš :-) 
        Random random = new Random();
        int[] arrayNumbers = new int[6];
        int[] counter = new int[6]; //máš 6 premenných pod sebou, každá ďalšia o jednu väčšia ako predchádzajúca. Prečo nevyužiť pole? Pozri, ako ti to potom zjednoduší metódu ToRoll() alebo TreePairs() :-)

        public string ToRoll()
        {
            //Dvakrát priradzuješ do jednej premennej hneď po sebe. Obecne to nie je chyba, ale je to neefektívne. Toto sú integeri, ale v prípade objektov to môže byť zbytočne náročné.
            for (int i = 0; i < arrayNumbers.Length; i++)
            {
                arrayNumbers[i] = random.Next(1, 7);
            }

            var builder = ""; //Super uvažovanie, do budúcna sa ti takýto prístup bude určite hodiť, že budeš mať objekty, ktoré ti pripravujú dáta na spracovanie. Akurát že pre tento jednoduchý príklad bohate stačilo var builder = ""; :-) 
            foreach (int number in arrayNumbers)
            {
                builder.Append(number);
                counter[number]++; //
            }

            return builder.ToString();

        }

        public string ToCalculate() //inak toto by som spravil úplne rovnako, najprv otestoval tie dve špeciálne prípady, a potom sa vrhol na jednotlivé čisla..
        {
            int resultNumber = 0;

            if (TreePairs(counter))
            {
                resultNumber = 800;
            }
            else if (oneCounter == 1 && twoCounter == 1 && threeCounter == 1 && fourCounter == 1 && fiveCounter == 1 && sixCounter == 1) //toto by sa dalo implementovať podobne ako ThreePairs(), akurát sa tie county musia rovnať 1
            {
                resultNumber = 1200;
            }
            else
            {
                resultNumber += Counter(oneCounter, 1000) + OneFiveCounter(oneCounter, 100) + Counter(twoCounter, 200) + Counter(threeCounter, 300) 
                    + Counter(fourCounter, 400) + Counter(fiveCounter, 500) + OneFiveCounter(fiveCounter, 50) + Counter(sixCounter, 600); 
                //toto kvôli čitateľnosti, šesť priradení do premennej pod sebou pôsobí divne. Akože tento zápis je robí doslova dopísmena to isté, ale menej znakov mi príde prehľadnejších.

            }
            return "Win points: " + resultNumber.ToString();

        }

        private int Counter(int rolledDiceNumber, int dicePointValue)
        {
            //toto už bude trošku zložitejšie. Keď si všimneš, tak čísla 1, 2, 4, 8 sú mocniny 2
            //Takže namiesto switchu vieš napísať krásnu formulku
            var multiplier = Math.Pow(2, rolledDiceNumber-3);
            return dicePointValue * multiplier;
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
                    counterNumber += 2 * dicePointValue;
                    break;
            }
            return counterNumber;
        }

        private bool TreePairs(int[] counter)
        {
            int pairNumber = 0;
            foreach count in counter {
                if (count == 2) pairNumber++;
            }
            return (pairNumber == 3);
        }

    }
}
