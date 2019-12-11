using System;
using System.Threading;

namespace Timer_Event
{
    /// <summary>
    /// This class generates the event.
    /// </summary>
    internal class Timer
    {
        /// <summary>
        /// Amount of seconds before getting massage.
        /// </summary>
        private int _seconds;

        /// <summary>
        /// Massage that must be send.
        /// </summary>
        private string _massage;        

        /// <summary>
        /// Event type of TimerArgs.
        /// </summary>
        public event EventHandler<TimerArgs> TimeEnd;

        /// <summary>
        /// Initializes a new instance of the <see cref="Timer"/> class. Constructor Timer.
        /// </summary>
        /// <param name="second">Amount of seconds before massage.</param>
        /// <param name="massage">Massage that must be send.</param>
        public void SetTimer(int second, string massage)
        {
            _seconds = second;
            _massage = massage;
        }

        /// <summary>
        /// This method responsible for event notification registered objects.
        /// </summary>
        /// <param name="sender">Reference to a class or structure, event-generating.</param>
        /// <param name="e">An object EventArgs or class, derived from EventArgs, providing event data.</param>
        public void OnTimerEnd(object sender, TimerArgs e)
        {
            if (this.TimeEnd != null)
            {
                TimeEnd(sender, e);
            }
        }

        /// <summary>
        /// Method that translates input information into a desired event.
        /// </summary>        
        public void Start()
        {
            Thread.Sleep(1000 * _seconds);
            OnTimerEnd(this, new TimerArgs(_massage));
        }
    }
}
