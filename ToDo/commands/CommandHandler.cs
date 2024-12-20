using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using Task = ToDo.model.Task;

namespace ToDo.commands
{
    public class CommandHandler
    {
        private Dictionary<string, ICommand> _commands = new();

        public CommandHandler()
        {
            _commands.Add(CommandActions.newTask, new NewCommand());
            _commands.Add(CommandActions.sortTasksAsc, new SortAscCommand());
            _commands.Add(CommandActions.sortTasksDsc, new SortDscCommand());
            _commands.Add(CommandActions.sortTasksByCreatedDateAsc, new SortCreatedDatesAscCommand());
            _commands.Add(CommandActions.sortTaskByCreatedDateDsc, new SortCreatedDatesDscCommand());
            _commands.Add(CommandActions.deleteTask, new DeleteCommand());
            _commands.Add(CommandActions.writeTasks, new WriteTasksCommand());
            _commands.Add(CommandActions.help, new HelpCommand());
        }

        public Task[] ExecuteCommandWithReturn(string command, Task[] tasks)
        {
            if (_commands.TryGetValue(command, out ICommand? value))
                return value.Execute(tasks);

            Console.WriteLine("Unknown Command. Insert help for possible commands.");
            return tasks;
        } 
        
        public void ExecuteCommand(string command, Task[]? tasks = null)
        {
            if (_commands.TryGetValue(command, out ICommand? value))
                value.Execute(tasks);
            else
                Console.WriteLine("Unknown command. Insert help for possible commands.");
        }
    }
}