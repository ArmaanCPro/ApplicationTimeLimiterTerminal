using System.Diagnostics;

namespace ApplicationTimeLimiterTerminal;

public class KillProcess
{
    public void Kill(string processName, bool killFamily)
    {
        foreach (var process in Process.GetProcessesByName(processName))
        {
            process.Kill(killFamily);
            process.WaitForExit();
        }
            
    }
}