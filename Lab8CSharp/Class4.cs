using System;
using System.Collections.Generic;
using System.IO;

public class BinaryProcessor
{
    public void Run()
    {
        string filePath = @"D:\Універ\2 курс\КПП\lab8\Lab8CSharp\reciprocals.bin";

        Console.Write("Введіть n (натуральне число): ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Невірне значення n.");
            return;
        }

        WriteReciprocalsToBinary(filePath, n);
        Console.WriteLine($"Файл '{filePath}' створено і записано числа 1, 1/2, ..., 1/{n}.");

        List<double> multiplesOfThree = ReadMultiplesOfThreeFromBinary(filePath);
        Console.WriteLine("Числа з порядковим номером, кратним 3:");

        int count = 3;
        foreach (double val in multiplesOfThree)
        {
            Console.WriteLine($"#{count}: {val}");
            count += 3;
        }
    }

    // Записує зворотні числа у двійковий файл
    public static void WriteReciprocalsToBinary(string filePath, int n)
    {
        using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
        {
            for (int i = 1; i <= n; i++)
            {
                double value = 1.0 / i;
                writer.Write(value);
            }
        }
    }

    // Читає числа з двійкового файлу, що мають порядковий номер, кратний 3
    public static List<double> ReadMultiplesOfThreeFromBinary(string filePath)
    {
        List<double> result = new List<double>();
        using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
        {
            int index = 1;
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                double value = reader.ReadDouble();
                if (index % 3 == 0)
                {
                    result.Add(value);
                }
                index++;
            }
        }
        return result;
    }
}
