
/*
 * Zadanie 1:
 * Napisz program, który umożliwi sortowanie bąbelkowe wartości wprowadzonych przez użytkownika.
 */

namespace Lab2.Task_1;

public static class Task1
{
    public static void Main()
    {
        const int numbersLen = 5;
        var numbers = new int[numbersLen];
        
        Console.WriteLine("Pobieranie wartosci...");

        for (var i = 0; i < numbersLen; i++)
        {
            Console.WriteLine("Podaj liczbe:");
            var input = Console.ReadLine();
            // Konwersja danych wejsciowych na liczbe
            var successParse = int.TryParse(input, out var number);
            if (!successParse)
            {
                Console.WriteLine("Wprowadzona wartosc to nie liczba. Domyslnie 0");
            }

            numbers[i] = successParse ? number : 0;
        }

        Console.WriteLine("Sortowanie elementow listy...\n");
        BubbleSort(numbers);
        
        // Formatowanie rezultatu
        var result = numbers.Aggregate("", (current, number) => current + (number.ToString() + " "));
        Console.WriteLine("Rezultat: " + result);
    }

    private static void BubbleSort(IList<int> numbers)
    {
        for (var j = numbers.Count - 1; j > 0; j--)
        {
            for (var i = 0; i < j; i++)
            {
                if (numbers[i] <= numbers[i + 1]) continue;
                (numbers[i], numbers[i + 1]) = (numbers[i + 1], numbers[i]);
            }
        }
    }
}