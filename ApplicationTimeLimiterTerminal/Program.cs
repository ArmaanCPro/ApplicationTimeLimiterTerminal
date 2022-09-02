using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;


namespace ApplicationTimeLimiterTerminal;

static class Program
{
    
    
    static void Main(string[] args)
    {
        
        //isRunning determines the state of the program
        bool isRunning = true;
        
        //Initialize a new key
        ConsoleKeyInfo key = new ConsoleKeyInfo();
        
        
        Console.WriteLine("Press escape to exit");
        
        Console.WriteLine();
        Console.WriteLine();
        
                    
        
        //Initialize the object outside of loop
        
        KillProcess explorer = new KillProcess();

        while (isRunning)
        {
            
            if (key.Key == ConsoleKey.Escape)
            {
                isRunning = false;
                break;
            }
            
            Console.WriteLine("Enter the program name");

            explorer.ProcessName = Convert.ToString(Console.ReadLine());
                
            explorer.KillIfLimitIsReached(explorer.ProcessName);
            
            Thread.Sleep(1000);
            
            
            
            Console.WriteLine("Would you like to set another limit? (y/n)");
            char answer = Convert.ToChar(Console.ReadLine());
            if (answer == 'y')
            {
                isRunning = true;
            }
            else if (answer == 'n')
            {
                isRunning = false;
            }
            else
            {
                Console.WriteLine("Invalid input");
                isRunning = false;
            }
        }

        
    }

}