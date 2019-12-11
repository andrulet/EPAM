using System;

namespace Timer_Event
{
    /// <summary>
    /// This class providing data for the event.
    /// </summary>
    internal class TimerArgs : EventArgs
    {
        /// <summary>
        /// Massage that must be get from event.
        /// </summary>
        private string message;       

        /// <summary>
        /// Initializes a new instance of the <see cref="TimerArgs"/> class. Constructor TimerArgs.
        /// </summary>
        /// <param name="message">Massage that must be get from event.</param>        
        public TimerArgs(string message)
        {
            this.Message = message;
        }

        /// <summary>
        /// Property message field.
        /// </summary>
        /// <value>Message field.</value>
        public string Message
        {
            get => this.message;
            internal set => this.message = value;
        }
    }
}
