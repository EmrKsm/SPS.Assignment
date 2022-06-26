using System.Text;

namespace SPS.Assignment.ConsoleUI.Helper
{
    public class FileHelper
    {
        public static async Task<IEnumerable<string>> GetLines()
        {
            string fileName = $@"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent}\poker.txt";
            var lines = await File.ReadAllLinesAsync(fileName);

            //List<string> lines = new();
            //const int BufferSize = 128;

            //using (var fileStream = File.OpenRead(fileName))
            //using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            //{
            //    string line;
            //    while ((line = streamReader.ReadLine()) != null)
            //    {
            //        lines.Add(line);
            //    }
            //}

            return lines;
        }
    }
}
