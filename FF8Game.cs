using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessMemoryReaderLib;
using System.Diagnostics;

namespace esthar_practice
{
    static class FF8Game
    {
        public static string GetVersion(Process ff8Game)
        {
            // Get the language from the process name (i.e. remove "FF8_" from the name)
            string GameVersion = ff8Game.ProcessName.Substring(4);

            // DO STUFF
            return GameVersion;
        }
        public static Process FindGame()
        {
            List<Process> processes = new List<Process>();
            processes = Process.GetProcesses()
            .Where(x => (x.ProcessName.StartsWith("FF8_", StringComparison.OrdinalIgnoreCase))
                        && !(x.ProcessName.Equals("FF8_Launcher", StringComparison.OrdinalIgnoreCase)))
            .ToList();

            if (processes.Count == 0)
                throw new NullReferenceException("Game not running.");

            return processes[0];
        }
    }
}
