using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Timer_Event
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var timer = new Timer();
            timer.SetTimer(3, "Time over.");
            timer.TimeEnd += delegate(object o, TimerArgs timerArgs)
            {
                Console.WriteLine($"First object receive message {timerArgs.Message}");
            };            
            timer.TimeEnd += delegate(object o, TimerArgs timerArgs)
            {
                Console.WriteLine($"Second object receive message {timerArgs.Message}");
            };            
            timer.TimeEnd += delegate(object o, TimerArgs timerArgs)
            {
                Console.WriteLine($"First object receive message {timerArgs.Message}");
            };            
            timer.Start();
            Console.ReadKey();
        }
    }
}
