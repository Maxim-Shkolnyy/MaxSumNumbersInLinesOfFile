using System;

namespace Maximal_sum_of_elements
{
    public class ConsoleIo : IConsoleIo
    {
        public void WriteLine(object message)
        {
            Console.WriteLine(message.ToString());
        }
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}