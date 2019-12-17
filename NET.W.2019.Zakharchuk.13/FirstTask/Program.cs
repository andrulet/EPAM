using System;

namespace FirstTask
{
    public class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Queue<string> arr = new Queue<string>();
                Queue<string> s = new Queue<string>();
                arr.Add("1");
                arr.Add("2");
                arr.Add("1000");
                arr.Add("1212");

                foreach (var a in arr)
                {
                    Console.WriteLine(a);
                }

                Console.WriteLine($"--------------------------------------");
                Console.WriteLine($"You are removed - " + arr.Remove());
                Console.WriteLine($"--------------------------------------");
                foreach (var a in arr)
                {
                    Console.WriteLine(a);
                }
                Console.WriteLine($"--------------------------------------");
                Console.WriteLine($"Check some numbers in ");
                Console.WriteLine($"{arr.Contains("1212")} - 1212");
                Console.WriteLine($"{arr.Contains("-1212")} - -1212");
                Console.WriteLine($"{arr.Contains("0")} - 0");

                //arr.Add(null);
                s.Remove();

                Console.ReadLine();
            }

            catch(ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
