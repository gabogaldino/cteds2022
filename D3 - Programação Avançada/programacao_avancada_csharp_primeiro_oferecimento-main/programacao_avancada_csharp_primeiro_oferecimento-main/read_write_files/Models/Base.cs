namespace read_write_files.Models
{
    /// <summary>
    /// Métodos comuns para manipulação de vários arquivos
    /// </summary>
    public class Base
    {
        /// <summary>
        /// Cria a pasta e o arquivo para armazenar os dados
        /// </summary>
        /// <param name="path">Caminho da pasta e do arquivo</param>
        public static void CreateFolderAndFile(string path)
        {
            string folder = path.Split("/")[0];

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }

        /// <summary>
        /// Lê todas as linhas do CSV
        /// </summary>
        /// <param name="path">Caminho da pasta e do arquivo</param>
        /// <returns>Retorna todas as linhas do arquivo</returns>
        public List<string> ReadAllLinesCSV(string path)
        {
            List<string> lines = new();

            using (StreamReader file = new(path))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            return lines;
        }

        /// <summary>
        /// Reescreve todas as linhas do CSV
        /// </summary>
        /// <param name="path">Caminho da pasta e do arquivo</param>
        /// <param name="lines">Lista com as linhas que serão reescritas</param>
        public void RewriteCSV(string path, List<string> lines)
        {
            using (StreamWriter output = new(path))
            {
                foreach (var line in lines)
                {
                    output.Write(line + "\n");
                    //output.WriteLine(line);
                }
            }
        }
    }
}
