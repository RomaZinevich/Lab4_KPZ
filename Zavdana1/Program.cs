
public interface ILogger
{
    void Log(string text);
    void Error(string text);
    void Warn(string text);
}

public class Logger : ILogger
{
    public void Log(string text)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(text);
        Console.ResetColor();
    }
    
    public void Error(string text)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    public void Warn(string text)
    {
        Console.ForegroundColor = ConsoleColor.Yellow; //Замість оранжового
        Console.WriteLine(text);
        Console.ResetColor();
    }
}

public interface IFileWriter
{
    void Write(string text);
    void WriteLine(string text);
}

public class FileWriter : IFileWriter
{
    private string message;

    public FileWriter(string message)
    {
        this.message = message;
    }

    public void Write(string text)
    {
        using (var streamWriter = new StreamWriter(message, true))
        {
            streamWriter.Write(text);
        }
    }

    public void WriteLine(string text)
    {
        using (var streamWriter = new StreamWriter(message, true))
        {
            streamWriter.WriteLine(text);
        }
    }
}

public class LoggerAdapter : ILogger
{
    private IFileWriter message;

    public LoggerAdapter(IFileWriter message)
    {
        this.message = message;
    }

    public void Log(string text)
    {
        message.WriteLine($"{text} [Log]");
    }

    public void Error(string text)
    {
        message.WriteLine($"{text} [Error]");
    }

    public void Warn(string text)
    {
        message.WriteLine($"{text} [Warn]");
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Використання консольного логера
        ILogger consoLogger = new Logger();
        consoLogger.Log("Якісь текст 1...");
        consoLogger.Error("Якісь текст 2..");
        consoLogger.Warn("Якісь текст 3..");

        // Використання файлового логера за допомогою адаптера
        IFileWriter fileWriter = new FileWriter("log.txt");
        ILogger fileLogger = new LoggerAdapter(fileWriter);
        fileLogger.Log("Якісь текст 1 ..");
        fileLogger.Error("Якісь текст 2 ..");
        fileLogger.Warn("Якісь текст 3 ..");
        
    }
}