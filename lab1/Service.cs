using Exception = System.Exception;

namespace lab1;

public class MyService
{
    public static void WriteLineToFile(string line, string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine(line);
        }

        
    }

    public static void ClearFile(string filePath)
    {
        using (FileStream fileStream = File.Open(filePath, FileMode.Create))
        {
            fileStream.SetLength(0);
        }
    }

    public static string[] ReadLinesFromFile(string filePath)
    {
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            return lines;
        }
        catch (IOException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}