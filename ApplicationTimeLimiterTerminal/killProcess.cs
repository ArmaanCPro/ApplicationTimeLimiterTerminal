using System.ComponentModel;
using System.Diagnostics;
using System.Dynamic;

namespace ApplicationTimeLimiterTerminal;

public class KillProcess
{
    //Overload Kill method with ClosMainWindow and Kill methods
    public void Kill(string? processName, bool killFamily)
    {
        foreach (var process in Process.GetProcessesByName(processName))
        {
            process.Kill(killFamily);
            process.WaitForExit();
            Console.WriteLine("Process {0} has been killed", processName);
            Console.WriteLine();
        }
            
    } 
    //Kill method overload
    public void Kill(string? processName)
    {
        foreach (var process in Process.GetProcessesByName(processName).Skip(1))
        {
            process.CloseMainWindow();
            process.WaitForExit();
            Console.WriteLine("Process {0} has been killed", processName);
            Console.WriteLine();
        }
            
    }
    
    
    public TimeSpan GetStartTime(string? processName)
    {
        // Get the start time of the process
        
        var procs = Process.GetProcessesByName(processName);
        
        foreach (var proc in procs)
        {
            
            try
            {
                //Get the amount of time the process has been running
                _runtime = DateTime.Now - proc.StartTime;
                

            }
            catch (Win32Exception ex)
            {
                // Ignore processes that give "access denied" error.
                if (ex.NativeErrorCode == 5)
                    continue;
                throw;
            }


        }

        return _runtime;


    }

    private float GetLimit()
    {
        
        //Ask for users limit

        
        Console.WriteLine("What is your limit?");

        limit = float.Parse(Console.ReadLine());


        return limit;
    }

    public void KillIfLimitIsReached(string processName)
    {
        //Get the start time of the process
        //If limit is greater than runtime, kill the process
        //Else output the number of time until limit is remaining
        
        if (GetStartTime(processName).TotalMinutes > GetLimit())
        {
            Kill(processName);
        }
        else
        {
            Console.WriteLine("You have " + _runtime.TotalMinutes + " minutes left");
            RemainingTime = _runtime;
            
            
            Console.WriteLine();
        }
    }

    public string? ProcessName { get; set; } = "explorer";
    
    private TimeSpan _runtime;
    private TimeSpan RemainingTime;

    private float limit;
}
