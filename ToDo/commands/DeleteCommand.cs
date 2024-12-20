using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.data;
using Task = ToDo.model.Task;

namespace ToDo.commands
{
    public class DeleteCommand : ICommand
    {
        public Task[] Execute(Task[] tasks)
        {
            Console.Write("Enter the Task ID to delete: ");
            string? idString = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(idString))
            {
                Console.WriteLine("Task ID cannot be empty.");
                return tasks;
            }

            if (!int.TryParse(idString, out int id))
            {
                Console.WriteLine("Invalid ID format. Please enter a valid number.");
                return tasks;
            }

            Task? taskToDelete = tasks.FirstOrDefault(t => t.EntityId.Id == id);
            if (taskToDelete == null)
            {
                Console.WriteLine($"No task found with ID {id}.");
                return tasks;
            }

            tasks = tasks.Where(t => t.EntityId.Id != id).ToArray();
            Data.Save(tasks);

            Console.WriteLine($"Task with ID {id} has been deleted.");
            return tasks;
        }
    }
}