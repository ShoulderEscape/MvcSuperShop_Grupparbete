using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Commands
{
    public class Commands
    {
        public class Foo : ConsoleAppBase
        {

            // echo --msg <String>
            [Command("echo", "--msg")]
            public void Echo(string msg, int repeat = 3)
            {
                
                for (var i = 0; i < repeat; i++)
                {
                    Console.WriteLine(msg);
                }
            }
            //--sum <int x> <int y>
            [Command("--sum", "x, y")]
            public void Sum([Option(0)] int x, [Option(1)] int y)
            {
                Console.WriteLine((x + y).ToString());
            }
        }
    }
}
