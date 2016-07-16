using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Timers
{
    public class TimerLauncher
    {
        public event EventHandler<NewTimerEventArgs> NewTimer = delegate { };

        //private static readonly ManualResetEvent mre = new ManualResetEvent(false);

        protected virtual void OnLaunchTimer(NewTimerEventArgs e)
        {
            //mre.WaitOne(e.TimerDuration);
            //temp(this, e);

            Thread timerStart = new Thread(ThreadProc);
            timerStart.Start(e);
        }

        public void SimulateTimerLauncher(string timerSender, TimeSpan timerDuration)
        {
            OnLaunchTimer(new NewTimerEventArgs(timerSender, timerDuration));
        }

        private void ThreadProc(object data)
        {
            NewTimerEventArgs args = data as NewTimerEventArgs;
            EventHandler<NewTimerEventArgs> temp = NewTimer;
            //mre.WaitOne(args.TimerDuration);
            Thread.Sleep(args.TimerDuration);
            temp(this, args);
        }
    }
}
