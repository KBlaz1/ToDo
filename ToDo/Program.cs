
using System;
using ToDo.commands;
using ToDo.data;
using ToDo.model;
using Task = ToDo.model.Task;

class Program
{
    private static Task[] Tasks = [];

    static void Main()
    {
        Tasks = Data.Load();
        CommandHandler commandHandler = new CommandHandler();
        commandHandler.ExecuteCommand(CommandActions.writeTasks, Tasks); 

        while (true)
        {

            Console.Write("\nCommand: ");
            string? command = Console.ReadLine().ToLower();

            if (command == "exit")
                break;

            if (command == CommandActions.help || command == CommandActions.writeTasks)
                commandHandler.ExecuteCommand(command, Tasks);
            else
                Tasks = commandHandler.ExecuteCommandWithReturn(command, Tasks);
        }

    }
}