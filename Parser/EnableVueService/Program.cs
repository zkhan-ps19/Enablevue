using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Diagnostics;


namespace EnableVue
{
    static class Program
    {
        static bool normal_flag = true;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {

            //  normal_flag = ! Debugger.IsAttached;

            if (normal_flag)
            {
                normal_flag = true;
                runNormal();
            }
            else
            {
                normal_flag = false;
                runDebug();
            }
        }

        static void runNormal()
        {
            //for installing

            ServiceBase[] ServicesToRun;
            Service1 svc = new Service1();
            svc.normFlag = normal_flag;
            ServicesToRun = new ServiceBase[] 
            { 
                svc
            };

            ServiceBase.Run(ServicesToRun);
        }
        static void runDebug()
        {
            // for debugging and direct running

            //#if DEBUG
            //While debugging this section is used.
            Service1 myService = new Service1();
            myService.normFlag = normal_flag;
            myService.onDebug();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);

            //#else
            //In Release this section is used. This is the "normal" way.
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
        { 
            myService 
        };
            ServiceBase.Run(ServicesToRun);
            ///#endif
        }


    }
}
