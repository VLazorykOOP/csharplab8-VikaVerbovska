using System;
using System.IO;

public class StudentFileManager
{
    private string studentName;
    private string basePath;
    private string dir1;
    private string dir2;
    private string allDir;

    public StudentFileManager(string studentName)
    {
        this.studentName = studentName;
        basePath = @"d:\temp";
        dir1 = Path.Combine(basePath, studentName + "1");
        dir2 = Path.Combine(basePath, studentName + "2");
        allDir = Path.Combine(basePath, "ALL");
    }

    public void ExecuteAllTasks()
    {
        CreateDirectories();
        CreateFiles();
        CreateCombinedFile();
        ShowDirectoryInfo(dir1);
        MoveAndCopyFiles();
        RenameAndCleanDirectories();
        ShowDirectoryInfo(allDir);
    }

    private void CreateDirectories()
    {
        Directory.CreateDirectory(dir1);
        Directory.CreateDirectory(dir2);
    }

    private void CreateFiles()
    {
        File.WriteAllText(Path.Combine(dir1, "t1.txt"), "<Шевченко Степан Іванович, 2001> року народження, місце проживання <м. Суми>");
        File.WriteAllText(Path.Combine(dir1, "t2.txt"), "<Комар Сергій Федорович, 2000> року народження, місце проживання <м. Київ>");
    }

    private void CreateCombinedFile()
    {
        string text1 = File.ReadAllText(Path.Combine(dir1, "t1.txt"));
        string text2 = File.ReadAllText(Path.Combine(dir1, "t2.txt"));
        File.WriteAllText(Path.Combine(dir2, "t3.txt"), text1 + Environment.NewLine + text2);
    }

    private void ShowDirectoryInfo(string path)
    {
        Console.WriteLine($"\nІнформація про файли у {path}:");
        foreach (string file in Directory.GetFiles(path))
        {
            FileInfo fi = new FileInfo(file);
            Console.WriteLine($"Файл: {fi.Name}, Розмір: {fi.Length} байт, Створено: {fi.CreationTime}");
        }
    }

    private void MoveAndCopyFiles()
    {
        File.Move(Path.Combine(dir1, "t2.txt"), Path.Combine(dir2, "t2.txt"));
        File.Copy(Path.Combine(dir1, "t1.txt"), Path.Combine(dir2, "t1.txt"), true);
    }

    private void RenameAndCleanDirectories()
    {
        if (Directory.Exists(allDir))
            Directory.Delete(allDir, true);

        Directory.Move(dir2, allDir);
        Directory.Delete(dir1, true);
    }
}
