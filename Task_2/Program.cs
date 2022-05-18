/*
 * Napisz program, który będzie przeprowadzał analizę statystyczną na podstawie wartości
 * występujących w tablicy.
     ▪ Długość tablicy podaje użytkownik ✅
     ▪ Wartości w tablicy są generowane ze zbioru dopuszczalnych wartości [2, 3, 3.5, 4, 4.5, 5] ✅
     ▪ Oblicz średnią wartość liczb występujących w tablicy ✅
     ▪ Znajdź wartość minimalną i maksymalną
     ▪ Znajdź wartości wyższe/niższe niż średnia
     ▪ Zlicz częstotliwość występowania poszczególnych liczb
     ▪ Oblicz średnie odchylenie standardowe wartości występujących w tablicy
 */

namespace Task_2;

public static class Task2
{
    public static void Main()
    {
        // Pobranie dlugosci tablicy od uzytkownika
        Console.WriteLine("Wprowadz dlugosc tablicy");
        // Konwersja input -> int
        var successParse = int.TryParse(Console.ReadLine(), out var arrayLen);
        if (!successParse)
        {
            Console.WriteLine("Nieprawidlowa wartosc. Domyslnie 0");
        }

        // Generowanie wartosci tablicy
        var givenValues = new[] {2, 3, 3.5, 4, 4.5, 5};
        var values = new double[arrayLen];

        // Wypelnianie tablicy losowymi liczbami ze zbioru
        for (var i = 0; i < arrayLen; i++)
        {
            // Losuj dopuszczalna wartosc
            var rnd = new Random();
            var randomIdx = rnd.Next(0, givenValues.Length);
            values[i] = givenValues[randomIdx];
        }

        var generationResult = values.Aggregate("", (current, number) => current + (number.ToString() + " "));
        Console.WriteLine("Wylosowane liczby: " + generationResult);
        
        // Oblicz srednia wartosc liczb wystepujacych w tablicy
        var valuesAverage = GetAverage(values);
        Console.WriteLine("Srednia wartosc liczb w tablicy wynosi: " + valuesAverage);
    }

    private static double GetAverage(IReadOnlyCollection<double> values)
    {
        return values.Sum() / values.Count;
    }
}