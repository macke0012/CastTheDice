namespace CastTheDice;

class Program
{
    static void Main(string[] args)
    {
        Random rnd = new();
        Console.WriteLine("Välkommen till cast the dice! Tärningarna kastas...");

        while (true)
        {
            int dice1 = rnd.Next(1, 7);
            int dice2 = rnd.Next(1, 7);
            PrintResult(dice1 + dice2);

            if (!WillContinue()) break;

            Console.Clear();



        }
    }

    static void PrintResult(int sum)
    {
        Console.WriteLine($"Resultat: {sum}");
        if (sum == 12)
        {
            Console.WriteLine($"Grattis du vann!");
            Thread.Sleep(500); //Bara så att man hinner reagera.
        }

    }

    static bool WillContinue()
    {

        Console.WriteLine("Vill du fortsätta? Y/N");
        ConsoleKey key = Console.ReadKey(true).Key;
        while (!IsValidInput(key))
        {
            Console.Clear();
            Console.WriteLine("Felaktig Inmatning, försök igen.");
            System.Console.WriteLine("Vill du fortsätta? Y/N");
            key = Console.ReadKey(true).Key;
        }


        return key == ConsoleKey.Y;

    }

    private static bool IsValidInput(ConsoleKey key)
    {
        return key == ConsoleKey.Y || key == ConsoleKey.N;
    }
}
