using Newtonsoft.Json;
using UserData.Models;

namespace UserData
{
    public class Program
    {
        static void Main(string[] args)
        {
            var content = GetFileContent();
            var users = JsonConvert.DeserializeObject<List<User>>(content);
        }

        private static string GetFileContent()
        {
            var relativePath = @"..\..\..\..\UserData.json";
            var jsonContent = File.ReadAllText(relativePath);
            return jsonContent;
        }
    }
}