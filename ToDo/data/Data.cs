using System.Text.Json;
using ToDo.model;
using Task = ToDo.model.Task;

namespace ToDo.data
{
    public static class Data
    {

        private const string FilePath = "data/tasksData.json";

        public static Task[] Load()
        {
            try
            {
                string jsonString = ReadFile(FilePath);
                return DeserializeTasks(jsonString);
            }
            catch (IOException ex)
            {
                LogError("The file could not be read", ex);
                return Array.Empty<Task>();
            }
            catch (JsonException ex)
            {
                LogError("Invalid JSON in the file", ex);
                return Array.Empty<Task>();
            }
        }

        // todo: figure out why this shit function is not saving to file
        public static void Save(Task[] tasks)
        {
            try
            {
                string json = JsonSerializer.Serialize<Task[]>(tasks);
                /*
                using (StreamWriter outputFile = new StreamWriter(FilePath, false))
                {
                    outputFile.Write(json);
                    outputFile.Flush();
                    outputFile.Close();
                }*/

                using (FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.ReadWrite))
                {
                    StreamWriter sw = new StreamWriter(fs);
                    sw.Write(json);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                LogError("Task saving failed", ex);
            }
        }

        private static string ReadFile(string path)
        {
            using StreamReader reader = new StreamReader(path);
            return reader.ReadToEnd();
        }

        private static Task[] DeserializeTasks(string jsonString)
        {
            Task[]? tasks = JsonSerializer.Deserialize<Task[]>(jsonString);
            return tasks ?? Array.Empty<Task>();
        }

        private static void LogError(string message, Exception ex)
        {
            Console.WriteLine(message);
            Console.WriteLine(ex.Message);
        }
    }
}
