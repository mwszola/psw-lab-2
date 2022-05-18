
/*
 * Zadanie 1:
 * Napisz program, który umożliwi sortowanie bąbelkowe wartości wprowadzonych przez użytkownika.
 */

namespace Lab2.Task_1;

public static class Task1
{
    public static void Main()
    {
        var numbers = new int[5];
        
        Console.WriteLine("Pobieranie wartosci...");

        for (var i = 0; i < 5; i++)
        {
            Console.WriteLine("Podaj liczbe:");
            var input = Console.ReadLine();
            var successParse = int.TryParse(input, out var number);
            if (!successParse)
            {
                Console.WriteLine("Wprowadzona wartosc to nie liczba. Domyslnie 0");
            }

            numbers[i] = successParse ? number : 0;
        }
        
        Console.WriteLine("\n\n");
        foreach (var number in numbers)
        {
            Console.WriteLine(number);
        }


        void bubbleSort(IList<int> numbers)
        {
            for (var i = 0; i < numbers.Count; i++)
            {
                
            }
        }
    }
}