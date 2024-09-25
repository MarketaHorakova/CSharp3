using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class FizzBuzz
{
    public void CountTo(int lastNumber)
    {
        for (int aktualniCislo = 1; aktualniCislo < lastNumber; aktualniCislo++)
        {
            if (aktualniCislo % 3 == 0 && aktualniCislo % 5 == 0)
            {
                Console.WriteLine("FizzBuzz");
                continue;
            }
            if (aktualniCislo % 3 == 0)
            {
                Console.WriteLine("Fizz");
                continue;
            }
            if (aktualniCislo % 5 == 0)
            {
                Console.WriteLine("Buzz");
                continue;
            }
            Console.WriteLine(aktualniCislo);
        }

    }
}
