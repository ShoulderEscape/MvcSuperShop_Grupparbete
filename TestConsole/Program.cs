using ConsoleAppFramework;
using TestConsole.Commands;
namespace TestConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            var app = ConsoleApp.Create(args);


            //app.AddCommands<Commands.Commands.Foo>();
            app.AddAllCommandType();
            app.Run();

        }
    }
}