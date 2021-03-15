using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace tinyServiceSample_console
{
    public class heartbeat
    {
        private readonly Timer _timer;

        public heartbeat()
        {
            _timer = new Timer(1000) { AutoReset = true };
            _timer.Elapsed += TimerElapsed;

        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            //throw new NotImplementedException();
            string[] lines = new string[] { DateTime.Now.ToString() };

            //insert a valid path ant create there a text file named as heartbeat
            File.AppendAllLines(@"C:\heartbeat.txt",lines);
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}
