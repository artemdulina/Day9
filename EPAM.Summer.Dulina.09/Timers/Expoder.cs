using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timers
{
    public class Expoder
    {
        public void RegisterOnTimer(TimerLauncher timer)
        {
            timer.NewTimer += Explosion;
        }

        public void Explosion(object sender, NewTimerEventArgs eventArgs)
        {
            Console.WriteLine($"Timer \"{eventArgs.TimerSender}\" triggered the explosion");
        }
    }
}
