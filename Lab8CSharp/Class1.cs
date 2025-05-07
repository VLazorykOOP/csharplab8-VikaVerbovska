using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class Lab8T2
{
    private string inputFile = @"D:\Універ\2 курс\КПП\lab8\Lab8CSharp\input.txt";
    private string outputFile = @"D:\Універ\2 курс\КПП\lab8\Lab8CSharp\ip_output.txt";
    private string replacedFile = @"D:\Універ\2 курс\КПП\lab8\Lab8CSharp\replaced_output.txt";

    public void Run()
    {
        if (!File.Exists(inputFile))
        {
            Console.WriteLine("Файл не знайдено: " + inputFile);
            return;
        }

        string text = File.ReadAllText(inputFile);

        string pattern = @"\b(?:(?:25[0-5]|2[0-4][0-9]|1?[0-9]{1,2})\.){3}(?:25[0-5]|2[0-4][0-9]|1?[0-9]{1,2})\b";
        MatchCollection matches = Regex.Matches(text, pattern);

        List<string> foundIPs = new List<string>();
        foreach (Match match in matches)
        {
            foundIPs.Add(match.Value);
        }

        File.WriteAllLines(outputFile, foundIPs);
        Console.WriteLine($"Знайдено {foundIPs.Count} IP-адрес(и). Вони записані у файл '{outputFile}'.");

        Console.Write("Введіть IP-адресу для заміни: ");
        string oldIP = Console.ReadLine();
        Console.Write("Введіть нову IP-адресу: ");
        string newIP = Console.ReadLine();

        string replacedText = Regex.Replace(text, $@"\b{Regex.Escape(oldIP)}\b", newIP);
        File.WriteAllText(replacedFile, replacedText);
        Console.WriteLine($"IP-адреса {oldIP} замінена на {newIP}. Результат збережено в '{replacedFile}'.");
    }
}
