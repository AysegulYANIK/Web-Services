using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace tinyServiceSample_console
{
    class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<heartbeat>(s =>
                    {
                        s.ConstructUsing(heartbeat => new heartbeat());
                        s.WhenStarted(heartbeat => heartbeat.Start());
                        s.WhenStopped(heartbeat => heartbeat.Stop());
                    });

                x.RunAsLocalSystem();
                x.SetServiceName("HeartbeatService");
                x.SetDisplayName("Heartbeat Service");
                x.SetDescription("This is a simple heartbeat service imitated from youtube video : by Tim Corey");


            });

            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }
    }
}
