using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.model;
using Task = ToDo.model.Task;

namespace ToDo.commands
{
    public class HelpCommand : ICommand
    {
        public Task[]? Execute(Task[]? tasks = null)
        {
            Console.WriteLine(
                "Commands:\n" +
                "\texit\t\t\tExits the program\n" +
                "\t" + CommandActions.help + "\t\t\tDisplay possible commands\n" +
                "\t" + CommandActions.writeTasks + "\t\t\tDisplay all tasks\n" +
                "\t" + CommandActions.newTask + "\t\t\tCreate a new task\n" +
                "\t" + CommandActions.deleteTask + "\t\t\tDelete a task\n" +
                "\t" + CommandActions.sortTasksAsc + "\t\tSort tasks by their due date and time in ascending order\n" +
                "\t" + CommandActions.sortTasksDsc + "\t\tSort tasks by their due date time in descending order\n" +
                "\t" + CommandActions.sortTasksByCreatedDateAsc + "\tSort tasks by their created date in ascending order\n" +
                "\t" + CommandActions.sortTaskByCreatedDateDsc + "\tSort tasks by their created date in descending order\n"
            );
            return null;
        }
    }
}