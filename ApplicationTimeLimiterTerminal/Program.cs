using System;
using System.Runtime.CompilerServices;


namespace ApplicationTimeLimiterTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            KillProcess explorer = new KillProcess();
            
            explorer.Kill("explorer", false);
            
        }
    }
}