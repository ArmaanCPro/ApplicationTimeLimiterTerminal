using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace ApplicationTimeLimiterTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            KillProcess explorer = new KillProcess();

            explorer.ProcessName = Convert.ToString(Console.ReadLine());

            if (explorer.ProcessName != null) explorer.Kill(explorer.ProcessName);
        }
    }
}