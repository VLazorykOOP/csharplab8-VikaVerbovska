using System;
using System.Collections.Generic;
using System.IO;

public class BinaryProcessor
{
    public void Run()
    {
        string filePath = @"D:\Універ\2 курс\КПП\lab8\Lab8CSharp\reciprocals.txt";

        Console.Write("Введіть n (натуральне число): ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Невірне значення n.");
            return;
        }

        WriteReciprocalsToText(filePath, n);
        Console.WriteLine($"Файл '{filePath}' створено і записано числа 1, 1/2, ..., 1/{n}.");

        List<double> multiplesOfThree = ReadMultiplesOfThreeFromText(filePath);
        Console.WriteLine("Числа з порядковим номером, кратним 3:");

        int count = 3;
        foreach (double val in multiplesOfThree)
        {
            Console.WriteLine($"#{count}: {val}");
            count += 3;
        }
    }


    public static void WriteReciprocalsToText(string filePath, int n)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            for (int i = 1; i <= n; i++)
            {
                double value = 1.0 / i;
                writer.WriteLine(value);
            }
        }
    }

    public static List<double> ReadMultiplesOfThreeFromText(string filePath)
    {
        List<double> result = new List<double>();
        string[] lines = File.ReadAllLines(filePath);

        for (int i = 2; i < lines.Length; i += 3) // 2, 5, 8, ... бо індексація з 0
        {
            if (double.TryParse(lines[i], out double val))
            {
                result.Add(val);
            }
        }

        return result;
    }
}
