using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            int greenCopy = greenLight;
            int freeCopy = freeWindow;

            Queue<string> queue = new Queue<string>();
            int passedCars = 0;

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "green")
                {
                    int currQueueCount = queue.Count;

                    for (int i = 0; i < currQueueCount; i++)
                    {
                        string currCar = queue.Peek();

                        if (greenCopy - queue.Peek().Length >= 0)
                        {
                            greenCopy -= queue.Dequeue().Length;
                            passedCars++;
                        }
                        else
                        {
                            if (greenCopy > 0)
                            {
                                if (queue.Peek().Length - greenCopy <= freeCopy)
                                {
                                    freeCopy -= queue.Dequeue().Length - greenCopy;
                                    greenCopy = 0;
                                    passedCars++;
                                }
                                else
                                {
                                    freeCopy -= queue.Peek().Length - greenCopy;
                                }
                            }
                        }

                        if (freeCopy < 0)
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{queue.Peek()} was hit at {queue.Peek()[queue.Peek().Length - greenCopy - 1]}.");
                            return;
                        }
                    }

                    greenCopy = greenLight;
                    freeCopy = freeWindow;
                }
                else
                {
                    queue.Enqueue(command);
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCars} total cars passed the crossroads.");
        }
    }
}
