using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Brighten
{
    public static class BrightnessManager
    {
        static public int CurrentBrightness
        {
            get
            {
                var item = new ManagementClass(@"root\wmi", "WmiMonitorBrightness", null).GetInstances().Cast<ManagementObject>().First();
                return int.Parse(item.GetPropertyValue("CurrentBrightness").ToString());
            }
            set
            {
                var method = new ManagementClass(@"root\wmi", "WmiMonitorBrightnessMethods", null).GetInstances().Cast<ManagementObject>().First();
                object[] param = { 0, value };
                method.InvokeMethod("WmiSetBrightness", param);
            }
        }
    }
}
