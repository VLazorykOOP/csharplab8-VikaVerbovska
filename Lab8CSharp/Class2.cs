using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

public class TextProcessor
{
    private string inputFile = @"D:\Універ\2 курс\КПП\lab8\Lab8CSharp\input.txt";
    private string outputFile = @"D:\Універ\2 курс\КПП\lab8\Lab8CSharp\words_output.txt";

    public void Run()
    {
        Console.Write("Введіть довжину слова: ");
        if (!int.TryParse(Console.ReadLine(), out int wordLength) || wordLength <= 0)
        {
            Console.WriteLine("Невірна довжина.");
            return;
        }

        try
        {
            List<string> words = GetWordsOfLength(inputFile, wordLength);

            if (words.Count == 0)
            {
                Console.WriteLine("Слів заданої довжини не знайдено.");
            }
            else
            {
                SaveWordsToFile(words, outputFile);
                Console.WriteLine($"Знайдено {words.Count} слово(слів) довжини {wordLength}. Записано у файл '{outputFile}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }

    private List<string> GetWordsOfLength(string filePath, int length)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("Файл не знайдено.");

        string text = File.ReadAllText(filePath);

        string[] words = Regex.Split(text, @"[^A-Za-zА-Яа-яІіЇїЄєҐґ0-9]+");

        List<string> result = new List<string>();
        foreach (string word in words)
        {
            if (word.Length == length)
                result.Add(word);
        }

        return result;
    }

    private void SaveWordsToFile(List<string> words, string outputFile)
    {
        File.WriteAllLines(outputFile, words);
    }
}
