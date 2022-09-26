using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Diagnostics;

namespace PcInfoWindows
{
    public class PcInfoReader
    {
        public void GetPcNameFromWMI()
        {
            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "Select Name FROM Win32_ComputerSystem");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    Console.WriteLine("\n-------------------------------------");
                    Console.WriteLine("Win32_ComputerSystem instance");
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("Name: {0}\n", queryObj["Name"]);
                }
            }
            catch(ManagementException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void GetHardDriveInfoFromWMI()
        {
            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "Select * FROM Win32_LogicalDisk");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    Console.WriteLine("\n-------------------------------------");
                    Console.WriteLine("Win32_LogicalDisk instance");
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("Volume Serial Number: {0}\n", queryObj["VolumeSerialNumber"]);
                    Console.WriteLine("Volume Serial Number: {0}\n", queryObj["Size"]);
                }
            }
            catch (ManagementException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void GetApplicationEventLog()
        {
            try
            {
                EventLog.GetEventLogs().
                    First(item => item.Log.Equals("Application", StringComparison.InvariantCultureIgnoreCase)).Entries.Cast<EventLogEntry>().
                    OrderByDescending(q => q.TimeWritten).
                    Take(10).
                    ToList().
                    ForEach(item => Console.WriteLine("{0} =>> {1}", item.Source, item.Message));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
