using ConsoleAppFramework;
using TestConsole.Commands;
namespace TestConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            var app = ConsoleApp.Create(args);

            app.AddAllCommandType();
            app.Run();

        }
    }
}