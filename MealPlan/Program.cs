using System;
using System.Collections.Generic;
using System.Linq;

namespace MealPlan
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> mealsInput = new Queue<string>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray());
            Stack<int> calorieIntakePerDay = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());

            int mealsCount = mealsInput.Count;
            int calCount = calorieIntakePerDay.Count;

            Queue<int> meals = new Queue<int>();

            foreach (var meal in mealsInput)
            {
                switch (meal)
                {
                    case "salad":
                        meals.Enqueue(350);
                        break;
                    case "soup":
                        meals.Enqueue(490);
                        break;
                    case "pasta":
                        meals.Enqueue(680);
                        break;
                    case "steak":
                        meals.Enqueue(790);
                        break;
                }
            }

            while (meals.Count > 0 && calorieIntakePerDay.Count > 0)
            {
                if (calorieIntakePerDay.Peek() - meals.Peek() > 0)
                {
                    int currCalorieIntake = calorieIntakePerDay.Pop() - meals.Peek();
                    calorieIntakePerDay.Push(currCalorieIntake);

                    meals.Dequeue();
                    mealsInput.Dequeue();
                }
                else if (calorieIntakePerDay.Peek() - meals.Peek() == 0)
                {
                    calorieIntakePerDay.Pop();
                    meals.Dequeue();
                    mealsInput.Dequeue();
                }
                else
                {
                    int newMeal = meals.Dequeue() - calorieIntakePerDay.Pop();
                    List<int> mealsArr = new List<int>(meals);
                    mealsArr.Insert(0, newMeal);

                    meals = new Queue<int>(mealsArr);

                    if (calorieIntakePerDay.Count == 0)
                    {
                        mealsInput.Dequeue();
                        meals.Dequeue();
                    }
                }
            }

            if (meals.Count == 0)
            {
                Console.WriteLine($"John had {mealsCount - meals.Count} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calorieIntakePerDay)} calories.");
            }

            if (meals.Count > 0)
            {
                Console.WriteLine($"John ate enough, he had {mealsCount - meals.Count} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", mealsInput)}.");
            }
        }
    }
}
