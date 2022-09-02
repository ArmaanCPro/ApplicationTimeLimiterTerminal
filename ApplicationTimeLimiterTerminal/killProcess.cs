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
        }
            
    } 
    public void Kill(string? processName)
    {
        foreach (var process in Process.GetProcessesByName(processName).Skip(1))
        {
            process.CloseMainWindow();
        }
            
    }

    public Process GetStartTime(string? processName)
    {
        var procs = Process.GetProcesses();
        
        foreach (var proc in procs)
        {
            TimeSpan runtime;
            try
            {
                runtime = DateTime.Now - proc.StartTime;
            }
            catch (Win32Exception ex)
            {
                // Ignore processes that give "access denied" error.
                if (ex.NativeErrorCode == 5)
                    continue;
                throw;
            }

            float limit = float.Parse(Console.ReadLine());
            
            
            
            
        }
    }

    public string? ProcessName { get; set; } = "explorer";
}
