using System.Formats.Asn1;
using Spectre.Console;
namespace CastTheDice;

class Program
{
    static List<int[]> history = new();
    static void Main(string[] args)
    {
        Random rnd = new();
        Console.WriteLine("Välkommen till cast the dice!");


        while (true)
        {
            int dice1 = rnd.Next(1, 7);
            int dice2 = rnd.Next(1, 7);
            AnsiConsole.Status()
            .Spinner(Spinner.Known.BouncingBall)
            .Start("Kastar tärningar", ctx =>
            {
                int[] entry = [dice1, dice2];
                history.Add(entry);
                Thread.Sleep(750);
            });
            PrintResult(dice1 + dice2);

            if (!WillContinue()) break;

            Console.Clear();



        }
    }

    static void PrintResult(int sum)
    {
        var table = new Table();
        table.RoundedBorder();
        table.AddColumns("Tärning 1", "Tärning 2", "Total");

        if (history.Count != 0)
        {
            history.ForEach(e => table.AddRow(e[0].ToString(), e[1].ToString(), e.Sum() == 12 ? "12 🥳" : e.Sum().ToString()));
        }
        AnsiConsole.Write(table);
        Console.WriteLine($"Resultat: {sum}");
        if (sum == 12)
        {
            Console.WriteLine($"Grattis du vann!");
            Thread.Sleep(500); //Bara så att man hinner reagera.
        }

    }

    static bool WillContinue()
    {

        var choice = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Vill du fortsätta?").AddChoices("Ja", "Nej"));


        return choice == "Ja";

    }


}
