using Greed;

RollDices greed = new RollDices();

for (int i = 0; i < 200; i++)
{
    Console.Write(greed.ToRoll());
    Console.Write(" - ");
    Console.WriteLine(greed.ToCalculate());
}


