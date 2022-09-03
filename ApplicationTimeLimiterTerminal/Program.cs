namespace ApplicationTimeLimiterTerminal;

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

        bool KillingProcess = true;

        while (isRunning)
        {
            
            
            
            Console.WriteLine("1. Kill Process");
            Console.WriteLine("2. Set Limit");
            Console.WriteLine("3. Exit");
            
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("Enter the program name");

                explorer.ProcessName = Convert.ToString(Console.ReadLine());
                
                Console.WriteLine();
                
                explorer.KillIfLimitIsReached(explorer.ProcessName);

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
            
            else
            {
                Console.WriteLine("Invalid input");
                isRunning = true;
            }


            Thread.Sleep(1000);
        }

        
    }

}