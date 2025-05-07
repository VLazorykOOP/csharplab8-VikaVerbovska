using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Оберіть завдання:");
        Console.WriteLine("1 - Робота з IP (Lab8T2)");
        Console.WriteLine("2 - Пошук слів заданої довжини (TextProcessor)");
        Console.WriteLine("3 - Видалення найдовших слів (TextCleaner)");
        Console.WriteLine("4 - Робота з двійковими файлами (BinaryProcessor)");
        Console.WriteLine("5 - Менеджер файлів студента (StudentFileManager)");  
        Console.Write("Ваш вибір: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                new Lab8T2().Run();
                break;

            case "2":
                new TextProcessor().Run();
                break;

            case "3":
                new TextCleaner().Run();
                break;

            case "4":
                new BinaryProcessor().Run();
                break;

            case "5":
                ExecuteAdditionalTask(); 
                break;

            default:
                Console.WriteLine("Невірний вибір.");
                break;
        }
    }

    static void ExecuteAdditionalTask()
    {
        try
        {
            StudentFileManager manager = new StudentFileManager("Вербовська");
            manager.ExecuteAllTasks();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }
    }
}
