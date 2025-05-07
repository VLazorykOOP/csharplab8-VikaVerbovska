using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

public class TextCleaner
{
    public void Run()
    {
        string inputFile = @"D:\Універ\2 курс\КПП\lab8\Lab8CSharp\input1.txt";
        string outputFile = @"D:\Універ\2 курс\КПП\lab8\Lab8CSharp\cleaned_output.txt";

        try
        {
            string cleanedText = RemoveLongestWords(inputFile);
            SaveCleanedText(cleanedText, outputFile);
            Console.WriteLine($"Слова найбільшої довжини вилучено. Результат записано у файл '{outputFile}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }

    // Метод для видалення найдовших слів
    public static string RemoveLongestWords(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("Файл не знайдено.");

        string text = File.ReadAllText(filePath);

        // Розбиття тексту на слова і розділові знаки
        string[] words = Regex.Split(text, @"(?<=[^\p{L}\p{N}])|(?=[^\p{L}\p{N}])");
        List<string> wordList = new List<string>(words);

        // Знаходження максимальної довжини
        int maxLen = 0;
        foreach (string word in wordList)
        {
            if (Regex.IsMatch(word, @"^\w+$") && word.Length > maxLen)
            {
                maxLen = word.Length;
            }
        }

        // Видалення слів максимальної довжини
        for (int i = 0; i < wordList.Count; i++)
        {
            if (Regex.IsMatch(wordList[i], @"^\w+$") && wordList[i].Length == maxLen)
            {
                wordList[i] = "";
            }
        }

        return string.Concat(wordList);
    }

    public static void SaveCleanedText(string text, string outputFile)
    {
        File.WriteAllText(outputFile, text);
    }
}
