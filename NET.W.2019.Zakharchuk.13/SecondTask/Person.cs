using System;

namespace SecondTask
{
    /// <summary>
    /// Event-generating class.
    /// </summary>   
    public class Person
    {
        public string S { get; private set; }
        public Person(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public string Subscribed(object sender, ElementEventArgs e)
        {
            S = $"Element of matrix [{e.I},{e.J}] was change. Person {this.Name} has been notified";
            return S;
        }
    }
}
