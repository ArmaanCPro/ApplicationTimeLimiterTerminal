using System;
using System.Runtime.CompilerServices;


namespace ApplicationTimeLimiterTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            KillProcess explorer = new KillProcess();
            
            Console.WriteLine("Which program would you like to terminate?");
            
            string processName = Console.ReadLine();
            explorer.Kill(processName, false);
            
        }
    }
}