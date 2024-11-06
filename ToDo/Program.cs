
using System;
using ToDo.data;
using Task = ToDo.model.Task;

class Program
{
    private static Task[] Tasks = [];

    static void Main()
    {
        Console.WriteLine("somethign blabla");
        Tasks = Data.Load();
        WriteTasks();

        bool exit = false;
        while (!exit)
        {

            Console.Write("\nCommand: ");
            string? command = Console.ReadLine();

            switch (command.ToLower())
            {
                case "help":
                    Help();
                    break;
                case "new":
                    NewTask();
                    WriteTasks();
                    break;
                case "delete":
                    Delete();
                    break;
                case "filter asc":
                    FilterDateAsc();
                    WriteTasks();
                    break;
                case "filter dsc":
                    FilterDateDesc();
                    WriteTasks();
                    break;
                case "exit":
                    exit = true;
                    break;
            }
        }
    }

    public static void WriteTasks()
    {
        for (int i = 0; i < Tasks.Length; i++)
        {
            Console.WriteLine("{0}\n{1}", i, Tasks[i]);
        }
    }

    public static void Help()
    {
        Console.WriteLine();
    }

    public static void NewTask()
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

        Tasks +=  new Task(newTitle, newDate, newTime);
        //Tasks = Tasks.Append(new Task(newTitle, newDate, newTime)).ToArray();
        Data.Save(Tasks);
    }

    public static void Delete()
    {
        while (true)
        {
            Console.Write("Index: ");
            string? indexString = Console.ReadLine();
            int index;

            if (indexString == null)
                continue;
            if (int.TryParse(indexString, out index))
                continue;
            if (index < 0 || index > Tasks.Length - 1)
                continue;

            Tasks = Tasks.Where((value, i) => i != index).ToArray();
            Data.Save(Tasks);
        }
    }

    // Bubble sort
    public static void FilterDateAsc()
    {
        for (int i = 0; i < Tasks.Length - 2; i++)
        {
            for (int j = 0; j < Tasks.Length - 2; j++)
            {
                if (Tasks[j].Date > Tasks[j + 1].Date)
                {
                    Task temp = Tasks[j + 1];
                    Tasks[j + 1] = Tasks[j];
                    Tasks[j] = temp;
                    break;
                }
            }
        }    
    }

    // Selection sort
    public static void FilterDateDesc()
    {
        int n = Tasks.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int min_idx = 1;

            for (int j = i + 1; j < n; j++)
            {
                if (Tasks[j].Date < Tasks[min_idx].Date)
                {
                    min_idx = j;
                }
            }

            Task temp = Tasks[i];
            Tasks[i] = Tasks[min_idx];
            Tasks[min_idx] = temp;
        }
    }
}

/*
public enum Options
{
    NEW_TASK,
    EDIT_TASK,
    DELETE_TASK,
    FILTER_DATE_DSC,
    FILTER_DATE_ASC,
}*/

