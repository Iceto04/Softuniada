using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.EasterBonuses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bonuses = new Dictionary<string, int>();

            while (true)
            {
                var name = Console.ReadLine();

                if (name == "stop")
                {
                    break;
                }

                var tasks = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToList();

                var bonus = 0;
                for (int i = 0; i < tasks.Count; i++)
                {
                    var currentTask = tasks[i];

                    tasks.RemoveAt(i);

                    var newTask = tasks.Aggregate((x, y) => x * y);

                    tasks.Insert(i, currentTask);

                    bonus += newTask;
                }

                if (!bonuses.ContainsKey(name))
                {
                    bonuses.Add(name, 0);
                }

                bonuses[name] = bonus;
            }
            var totalBonuses = 0;
            foreach (var kvp in bonuses)
            {
                Console.WriteLine($"{kvp.Key} has a bonus of {kvp.Value} lv.");
                totalBonuses += kvp.Value;
            }

            Console.WriteLine($"The amount of all bonuses is {totalBonuses} lv.");
        }
    }
}
