using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timers
{
    public sealed class NewTimerEventArgs : EventArgs
    {
        public string TimerSender { get; }

        public TimeSpan TimerDuration { get; }

        public NewTimerEventArgs(string timerSender, TimeSpan timerDuration)
        {
            TimerSender = timerSender;
            TimerDuration = timerDuration;
        }
    }
}
