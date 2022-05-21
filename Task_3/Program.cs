/*
 * Zadanie
 
   Napisz program, który pozwoli na wykonanie podstawowych operacji na macierzach kwadratowych o wymiarach podanych przez użytkownika:
    ▪ Dodawanie dwóch macierzy ✅ 
    ▪ Odejmowanie dwóch macierzy ✅
    ▪ Mnożenie dwóch macierzy ✅

    Do implementacji macierzy wykorzystaj tablice wielowymiarowe, które będą automatycznie wypełnione wartościami losowymi z zakresu od -10 do 10. 
 */

namespace Task_3;

public static class Task3
{
    public static void Main()
    {
        /* Pobranie wymiaru macierzy kwadratowej do uzytkownika */
        Console.WriteLine("Prosze, podaj liczbe wierszy macierzy kwadratowej");
        var lengthParseSuccess = int.TryParse(Console.ReadLine(), out var matrixLen);
        if (!lengthParseSuccess)
        {
            Console.WriteLine("Nieprawidlowa wartosc. Domyslny wymiar macierzy to 5 x 5");
            matrixLen = 5;
        }

        // Utworzenie macierzy (tablicy 2-wymiarowej)
        var matrix1 = new int[matrixLen, matrixLen];
        var matrix2 = new int[matrixLen, matrixLen];
        var rnd = new Random();
        
        // Wypelnienie macierzy losowymi liczbami z zakresu <-10;10>
        for (var row = 0; row < matrixLen; row++)
        {
            for (var col = 0; col < matrixLen; col++)
            {
                // Wylosowanie liczb oraz wypelnienie macierzy
                matrix1[row, col] = rnd.Next(-10, 11);
                matrix2[row, col] = rnd.Next(-10, 11);
            }
        }
        
        /* Wyswietlenie macierzy */
        Console.WriteLine("Macierz pierwsza:");
        PrintMatrix(matrix1, matrixLen, matrixLen);
        Console.WriteLine("Macierz druga:");
        PrintMatrix(matrix2, matrixLen, matrixLen);
        
        /* Dodanie macierzy oraz wyswietlenie wyniku */
        var sumMatrix = AddMatrices(matrix1, matrix2, matrixLen, matrixLen);
        Console.WriteLine("Suma macierzy:");
        PrintMatrix(sumMatrix, matrixLen, matrixLen);
        
        /* Odejmowanie macierzy oraz wyswietlenie wyniku */
        var subtractMatrix = SubtractMatrices(matrix1, matrix2, matrixLen, matrixLen);
        Console.WriteLine("Roznica macierzy:");
        PrintMatrix(subtractMatrix, matrixLen, matrixLen);
        
        /* Mnozenie macierzy oraz wyswietlenie wyniku */        
        var multiplyMatrix = MultiplyMatrices(matrix1, matrix2, matrixLen, matrixLen);
        Console.WriteLine("Wynik mnozenia macierzy:");
        PrintMatrix(multiplyMatrix, matrixLen, matrixLen);

    }

    private static void PrintMatrix(int[,] matrix, int rowsLen, int colsLen)
    {
        for (var row = 0; row < rowsLen; row++)
        {
            var rowResult = "";
            for (var col = 0; col < colsLen; col++)
            {
                rowResult += matrix[row, col] + " ";
            }
            Console.WriteLine(rowResult);
        }
    }

    private static int[,] AddMatrices(int[,] matrix1, int[,] matrix2, int rowsLen, int colsLen)
    {
        /* Dodanie do siebie dwoch macierzy, rezultatem jest macierz */
        var sumMatrix = new int [rowsLen, colsLen];
        for (var row = 0; row < rowsLen; row++)
        {
            for (var col = 0; col < colsLen; col++)
            {
                sumMatrix[row, col] = matrix1[row, col] + matrix2[row, col];
            }
        }

        return sumMatrix;
    }
    
    private static int[,] SubtractMatrices(int[,] matrix1, int[,] matrix2, int rowsLen, int colsLen)
    {
        /* Odejmowanie macierzy */
        var subtractMatrix = new int [rowsLen, colsLen];
        for (var row = 0; row < rowsLen; row++)
        {
            for (var col = 0; col < colsLen; col++)
            {
                subtractMatrix[row, col] = matrix1[row, col] - matrix2[row, col];
            }
        }

        return subtractMatrix;
    }
    
    private static int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2, int rowsLen, int colsLen)
    {
        /* Mnozenie macierzy */
        var multiplyMatrix = new int [rowsLen, colsLen];
        for (var row = 0; row < rowsLen; row++)
        {
            for (var col = 0; col < colsLen; col++)
            {
                multiplyMatrix[row, col] = 0;
                for (var i = 0; i < rowsLen; i++)
                {
                    multiplyMatrix[row, col] += matrix1[row, i] * matrix2[i, col];
                } 
            }
            
        }

        return multiplyMatrix;
    }
}