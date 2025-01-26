using Newtonsoft.Json;
using System.Text;

namespace TesteIbmMQ.Infraestructure.Repositories
{
    public class SystemFilesRepository
    {
        public void CreateFile(string directory, string fileName, string extension, string content)
        {
            string filePath = Path.Combine(directory, $"{fileName}.{extension}");

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (File.Exists(filePath))
            {
                throw new Exception("File already exists.");
            }

            // Create the file
            using (FileStream fs = File.Create(filePath))
            {
                // Optionally write some content to the file
                byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                fs.Write(info, 0, info.Length);
            }

            Console.WriteLine("File created successfully.");
        }

        public T ReadFile<T>(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found.", filePath);
            }

            string jsonContent = File.ReadAllText(filePath);
            if (string.IsNullOrEmpty(jsonContent))
            {
                throw new Exception("File is empty.");
            }

            T result = JsonConvert.DeserializeObject<T>(jsonContent);

            if (result == null)
            {
                throw new Exception("Error deserializing file content.");
            }
            return result;
        }

    }
}
