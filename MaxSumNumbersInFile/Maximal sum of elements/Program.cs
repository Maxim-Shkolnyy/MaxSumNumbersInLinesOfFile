namespace Maximal_sum_of_elements;

public class Program
{
    static void Main(string[] args)
    {
        ProgramManager programManager = new ProgramManager(new ConsoleIo(), new FileGetter());
        programManager.DoWork();
    }
}
