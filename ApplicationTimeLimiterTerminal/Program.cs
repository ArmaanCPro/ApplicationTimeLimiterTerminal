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

        bool KillingProcess = true;

        while (isRunning)
        {
            
            if (key.Key == ConsoleKey.Escape)
            {
                isRunning = false;
                break;
            }
            
            
            Console.WriteLine("1. Kill Process");
            Console.WriteLine("2. Set Limit");
            Console.WriteLine("3. Exit");
            
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
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
            
            else if (choice == 2)
            {
                
            }
           
        }

        
    }

}