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
}