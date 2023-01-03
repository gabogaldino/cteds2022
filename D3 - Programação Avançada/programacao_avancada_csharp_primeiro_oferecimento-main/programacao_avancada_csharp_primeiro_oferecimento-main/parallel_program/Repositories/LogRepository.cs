using parallel_program.Interfaces;
using parallel_program.Models;
using System.Text;

namespace parallel_program.Repositories
{
    internal class LogRepository : ILog
    {
        private const string path = "database/log.txt";
        private readonly FileStream fileStream;

        public LogRepository(FileStream fileStream)
        {
            CreateFolderAndFile(path);
            this.fileStream = fileStream;
        }

        private static string PrepareLine(User user)
        {
            return $"O usuário: {user.Name} ({user.JobTitle}) está acessando dados do banco. {DateTime.Now} \n";
        }

        public static void CreateFolderAndFile(string path)
        {
            string folder = path.Split("/")[0];

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if (!File.Exists(path))
            {
                File.Create(path);
            }
        }

        public void RegisterAccess(User user)
        {
            string line = PrepareLine(user);
            byte[] info = new UTF8Encoding(true).GetBytes(line);
            fileStream.Write(info);
        }
    }
}
