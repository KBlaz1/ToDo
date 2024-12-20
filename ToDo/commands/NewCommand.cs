using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.data;
using ToDo.model;
using Task = ToDo.model.Task;

namespace ToDo.commands
{
    public class NewCommand : ICommand
    {
        public Task[] Execute(Task[] tasks)
        {
            string? newTitle, newDateString, newTimeString;
            DateOnly newDate;
            TimeOnly newTime;

            while (true)
            {
                Console.Write("Title: ");
                newTitle = Console.ReadLine();

                if (!string.IsNullOrEmpty(newTitle))
                    break;
                else
                    Console.WriteLine("Title was null or empty!\n Please try again!");
            }

            while (true)
            {
                Console.Write("Date: ");
                newDateString = Console.ReadLine();

                if (!string.IsNullOrEmpty(newDateString))
                {
                    try
                    {
                        newDate = DateOnly.Parse(newDateString);
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("The date was invalid!\n Try again!");
                    }
                }
                else
                {
                    Console.WriteLine("Title was null or empty!\n Try again!");
                }
            }

            while (true)
            {
                Console.Write("Time: ");
                newTimeString = Console.ReadLine();

                if (!string.IsNullOrEmpty(newTimeString))
                {
                    try
                    {
                        newTime = TimeOnly.Parse(newTimeString);
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("The time was invalid!\n Try again!");
                    }
                }
                else
                {
                    Console.WriteLine("Time was null or empty!\n Try again!");
                }
            }

            List<int> ids = new List<int>();
            ids = tasks.Select((t) => t.EntityId.Id).ToList();
            tasks += new Task(newTitle, new DateTime(newDate, newTime), EntityId.Create(ids), DateTime.Now);
            Data.Save(tasks);
            return tasks;
        }
    }
}