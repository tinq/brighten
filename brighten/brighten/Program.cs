using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brighten
{
    class Program
    {
        static void Main(string[] args)
        {
            // no param
            if (args.Length == 0)
            {
                Console.WriteLine(BrightnessManager.CurrentBrightness);
            }
            else if (args[0] == "--help")
            {
                Console.WriteLine(@"Usage: brighten [param]

No Paramater        print current brigthness.
0~100               set brightness to the argument.
+0~100 or -0~100    set brightness to the (argument + or - curreont value). 
--help              show this help.

(C)tinq 2015. Version 0.1");
            }else{
                int val;
                if (int.TryParse(args[0], out val))
                {
                    if (args[0][0] == '+' || args[0][0] == '-') BrightnessManager.CurrentBrightness += val;
                    else BrightnessManager.CurrentBrightness = val;
                }
                else
                {
                    Console.Error.WriteLine("Invalid Paramater.\nTry `brighten --help` for more information.");
                }
            }
        }
    }
}