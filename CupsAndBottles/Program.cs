using System;
using System.Collections.Generic;
using System.Linq;

namespace CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cupsCapacity = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> filledBottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            int waterWasted = 0;

            while (cupsCapacity.Count > 0 && filledBottles.Count > 0)
            {
                if (cupsCapacity.Peek() - filledBottles.Peek() <= 0)
                {
                    waterWasted += Math.Abs(cupsCapacity.Dequeue() - filledBottles.Pop());
                }
                else
                {
                    int remainderCup = cupsCapacity.Peek() - filledBottles.Peek();

                    while (remainderCup > 0)
                    {
                        remainderCup -= filledBottles.Peek();

                        if (remainderCup < 0)
                        {
                            waterWasted += Math.Abs(cupsCapacity.Dequeue() - filledBottles.Pop());
                        }
                        else if (remainderCup == 0)
                        {
                            cupsCapacity.Dequeue();
                            filledBottles.Pop();
                        }
                        else
                        {
                            filledBottles.Pop();
                        }
                    }
                }
            }
        }
    }
}
