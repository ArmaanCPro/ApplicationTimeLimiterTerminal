﻿namespace ApplicationTimeLimiterTerminal;

static class Program
{
    static void Main(string[] args)
    {
        //isRunning determines the state of the program
        bool isRunning = true;
        Console.WriteLine("Press escape to exit");
        Console.WriteLine();
        Console.WriteLine();
        //Initialize the object outside of loop
        KillProcess explorer = new KillProcess();
        while (isRunning)
        {
            Console.WriteLine("1. Kill Process");
            Console.WriteLine("2. Set Limit");
            Console.WriteLine("3. Exit");
            Console.WriteLine("4. View Process");
            
            Console.WriteLine();

            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("Enter the program name");
                explorer.ProcessName = Convert.ToString(Console.ReadLine());
                Console.WriteLine();
                
                if (explorer.ProcessName != null) //Null safety check
                    explorer.Kill(explorer.ProcessName, true);
                    //explorer.KillIfLimitIsReached(explorer.ProcessName);
                
                
                isRunning = true;
            }
            else if (choice == 2)
            {
                explorer.SetTimer();
                isRunning = true;
            }
            else if (choice == 3)
            {
                isRunning = false;
            }
            else if (choice == 4)
            {
                Console.WriteLine("You have " + explorer.GetRuntime() + " minutes left");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Invalid input");
                isRunning = true;
            }
            Thread.Sleep(1000);
        }
    }
}