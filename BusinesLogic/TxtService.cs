using System.Text;

namespace BusinesLogic
{
    public class TxtService
    {
        public async Task<string> SearchFile(string fileName)
        {
            var result = "";
            using (var fileStream = new FileStream(fileName, FileMode.Open))
            {
                byte[] buffer = new byte[fileStream.Length];
                await fileStream.ReadAsync(buffer);
                result = Encoding.Default.GetString(buffer);
            }            
            return result;
        }

        public async Task Save(string fileName, string text)
        {
            byte[] result = Encoding.UTF8.GetBytes(text);
            using var fileStream = new FileStream(fileName, FileMode.Open);
            fileStream.SetLength(0);

            await fileStream.WriteAsync(result);
        }
    }
}