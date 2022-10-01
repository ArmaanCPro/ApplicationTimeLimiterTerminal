using System.ComponentModel;
using System.Diagnostics;
using Timer = System.Timers.Timer;

namespace ApplicationTimeLimiterTerminal;

public class KillProcess
{
    //Overload Kill method with CloseMainWindow and Kill methods
    public void Kill(string? processName, bool killFamily)
    {
        foreach (var process in Process.GetProcessesByName(processName))
        {
            process.Kill(killFamily);
            Console.WriteLine("Process {0} has been killed", processName);
            Console.WriteLine();
        }
            
    } 
    //Kill method overload
    private void Kill(string? processName)
    {
        foreach (var process in Process.GetProcessesByName(processName).Skip(1))
        {
            process.CloseMainWindow();
            Console.WriteLine("Process {0} has been killed", processName);
            Console.WriteLine();
        }
            
    }
    
    
    private TimeSpan GetStartTime(string? processName)
    {
        // Get the start time of the process
        
        var procs = Process.GetProcessesByName(processName);


        
        
        foreach (var proc in procs)
        {
            
            try
            {
                //Get the amount of time the process has been running
                runtime = DateTime.Now - proc.StartTime;
                
            }
            catch (Win32Exception ex)
            {
                // Ignore processes that give "access denied" error.
                if (ex.NativeErrorCode == 5)
                    continue;
                throw;
            }


        }

        return runtime;


    }

    private float GetLimit()
    {
        
        //Get for users limit

        Console.WriteLine("What is the limit?");

        limit = float.Parse(Console.ReadLine() ?? string.Empty);


        return limit;
    }

    public void KillIfLimitIsReached(string processName)
    {
        //Get the start time of the process
        //If limit is greater than runtime, kill the process
        //Else output the number of time until limit is remaining
        
        if (GetStartTime(processName).TotalMinutes > GetLimit())
        {
            Kill(processName, true);
        }
        else
        {
            Console.WriteLine("You have " + runtime.TotalMinutes + " minutes left");

        }
        
    }
    
    public void SetTimer()
    {
        Console.WriteLine("How long would you like the limit to be? (minutes)");
        float time = float.Parse(Console.ReadLine() ?? throw new InvalidOperationException());


        Console.WriteLine("What is the name of the program?");

        string processName = Console.ReadLine() ?? throw new InvalidOperationException();
        
        Console.WriteLine();

        TimedProcessName = processName;
        
        RemainingTimer.Interval = time * 60000;
        RemainingTimer.Start();
        
        Console.WriteLine("Timer set");
        Console.WriteLine();

        
        RemainingTimer.AutoReset = false;
        
        RemainingTimer.Elapsed += (sender, args) => HandleTimer();
 
        
    }

    void HandleTimer()
    {
        Kill(TimedProcessName, true);
        RemainingTimer.Stop();
        RemainingTimer.Dispose();
        
        Console.WriteLine("Program has been killed");
        Console.WriteLine();

    }

    public double GetRuntime()
    {
        return (Double.Parse(RemainingTimer.Interval.ToString())) / 60000; //Dividing by 60000 to get minutes, otherwise it is in seconds
    }

    public string? ProcessName { get; set; } = "explorer";
    
    private TimeSpan runtime;
    

    //private TimeSpan RemainingTime;

    
    private Timer RemainingTimer = new Timer(1000000000);

    private float limit;

    private string TimedProcessName;
}
