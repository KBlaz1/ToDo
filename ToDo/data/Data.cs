using System.Text.Json;
using System.Text.Json.Serialization;
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

        public static void Save(Task[] tasks)
        {
            try
            {
                JsonSerializerOptions options = new()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // Ensure camelCase is respected if needed
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, // Ignore null properties
                    WriteIndented = true
                };
                string json = JsonSerializer.Serialize<Task[]>(tasks, options);
                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex)
            {
                LogError("Task saving failed", ex);
            }
        }

        private static string ReadFile(string path)
        {
            try
            {
                using StreamReader reader = new StreamReader(path);
                return reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                LogError("File could not be read", ex);
                throw;
            }
        }

        private static Task[] DeserializeTasks(string jsonString)
        {
            JsonSerializerOptions options = new()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // Ensure camelCase is respected if needed
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, // Ignore null properties
                WriteIndented = true
            };
            Task[]? tasks = JsonSerializer.Deserialize<Task[]>(jsonString, options);
            return tasks ?? Array.Empty<Task>();
        }

        private static void LogError(string message, Exception ex)
        {
            Console.WriteLine(message);
            Console.WriteLine(ex.Message);
        }
    }
}
