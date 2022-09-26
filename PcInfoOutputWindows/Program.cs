using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcInfoWindows;

namespace PcInfoOutputWindows
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PcInfoReader pcInfoReader = new PcInfoReader();
            //pcInfoReader.GetPcNameFromWMI();
            //pcInfoReader.GetHardDriveInfoFromWMI();
            pcInfoReader.GetApplicationEventLog();
        }
    }
}
