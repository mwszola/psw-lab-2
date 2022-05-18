/*
 * Napisz program, który będzie przeprowadzał analizę statystyczną na podstawie wartości
 * występujących w tablicy.
     ▪ Długość tablicy podaje użytkownik ✅
     ▪ Wartości w tablicy są generowane ze zbioru dopuszczalnych wartości [2, 3, 3.5, 4, 4.5, 5] ✅
     ▪ Oblicz średnią wartość liczb występujących w tablicy ✅
     ▪ Znajdź wartość minimalną i maksymalną ✅
     ▪ Znajdź wartości wyższe/niższe niż średnia ✅
     ▪ Zlicz częstotliwość występowania poszczególnych liczb ✅
     ▪ Oblicz średnie odchylenie standardowe wartości występujących w tablicy ✅
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

        var generationResult = values.Aggregate("", (current, number) => current + (number + " "));
        Console.WriteLine("Wylosowane liczby: " + generationResult);

        // Oblicz srednia wartosc liczb wystepujacych w tablicy
        var valuesAverage = GetAverage(values);
        Console.WriteLine("Srednia wartosc liczb w tablicy wynosi: " + valuesAverage);

        // Znajdź wartość minimalną i maksymalną
        var minValue = FindMin(values);
        var maxValue = FindMax(values);
        Console.WriteLine("Wartosc minimalna = " + minValue + ", mayksymalna = " + maxValue);

        // Znajdź wartości wyższe/niższe niż średnia
        var valuesAboveAverage = "";
        var valuesBelowAverage = "";
        foreach (var value in values)
        {
            if (value < valuesAverage)
            {
                valuesBelowAverage += value + " ";
            }
            else if (value > valuesAverage)
            {
                valuesAboveAverage += value + " ";
            }
        }

        Console.WriteLine("Wartosc wyzsze niz srednia: " + valuesAboveAverage);
        Console.WriteLine("Wartosc nizsze niz srednia: " + valuesBelowAverage);
        
        // Zlicz częstotliwość występowania poszczególnych liczb
        var frequenciesResult = GetValuesFrequencyResult(values);
        Console.WriteLine("Czestotliwosc wystepowania liczb:\n" + frequenciesResult);
        
        // Oblicz średnie odchylenie standardowe wartości występujących w tablicy
        var standardDeviation = GetStandardDeviation(values);
        Console.WriteLine("Srednie odchylenie standardowe wynosi: " + standardDeviation);
    }

    private static double GetAverage(IReadOnlyCollection<double> values)
    {
        return values.Sum() / values.Count;
    }

    private static double FindMin(IReadOnlyList<double> values)
    {
        var min = values[0];
        for (var i = 1; i < values.Count; i++)
        {
            if (values[i] < min)
            {
                min = values[i];
            }
        }

        return min;
    }

    private static double FindMax(IReadOnlyList<double> values)
    {
        var max = values[0];
        for (var i = 1; i < values.Count; i++)
        {
            if (values[i] > max)
            {
                max = values[i];
            }
        }

        return max;
    }

    private static string GetValuesFrequencyResult(double[] values)
    {
        // Utworz slownik zawierajacy jako klucz liczbe, a jako wartosc liczbe wystepowan
        var frequencies = new Dictionary<double, int>();
        // Wypelnij slownik zerami
        foreach (var value in values)
        {
            frequencies[value] = 0;
        }

        // Zwiekszaj liczbe wystepowan dla danej liczby
        foreach (var value in values)
        {
            frequencies[value]++;
        }

        /* Utworz i zwroc wynik w postaci lancucha tekstowego utworzony na podstawie slownika
         zawieracajcego czestotliwosci wystepowania liczb */
        return frequencies.Aggregate("", (current, frequency) => current + (frequency.Key + " = " +
            frequency.Value + "" +
            "\n"));
    }

    // Metoda liczaca srednie odchylenie standardowe
    private static double GetStandardDeviation(IReadOnlyCollection<double> values)
    {
        // Oblicz srednia arytmetyczna z wartosci
        var average = GetAverage(values);

        // Oblicz odchylenie standardowe zgodnie z formula
        
        // Suma poteg kwadratowych, roznicy wartosci i sredniej arytmetycznej liczb
        var result = values.Sum(value => Math.Pow((value - average), 2.0));
        // ... podzielona przez ilosc liczb = wariancja
        result /= values.Count;
        // ... pierwiastek kwadratowy z wariancji
        result = Math.Pow(result, 0.5);
        // ... daje nam wynik
        return result;
    }
}