using System.Diagnostics;

namespace ApplicationTimeLimiterTerminal;

public class KillProcess
{
    //Overload Kill method with ClosMainWindow and Kill methods
    public void Kill(string processName, bool killFamily)
    {
        foreach (var process in Process.GetProcessesByName(processName))
        {
            process.Kill(killFamily);
            process.WaitForExit();
        }
            
    }
    public void Kill(string processName)
    {
        foreach (var process in Process.GetProcessesByName(processName))
        {
            process.CloseMainWindow();
        }
            
    }
}
