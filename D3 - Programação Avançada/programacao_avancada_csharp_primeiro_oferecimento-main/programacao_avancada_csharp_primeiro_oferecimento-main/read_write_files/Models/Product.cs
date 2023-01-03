using read_write_files.Interfaces;

namespace read_write_files.Models
{
    /// <summary>
    /// Propriedades e métodos que definem um produto
    /// </summary>
    internal class Product : Base, IProduct
    {
        public string IdProduct { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        private const string path = "database/product.csv";

        /// <summary>
        /// A cada instância de produto, verifica se a pasta e o arquivo existem
        /// </summary>
        public Product()
        {
            CreateFolderAndFile(path);
        }

        /// <summary>
        /// Define a estrutura da linha do CSV
        /// </summary>
        /// <param name="product">Objeto com os dados que serão gravados</param>
        /// <returns>Retorna a linha preparada para ser gravada</returns>
        private static string PrepareLine(Product product)
        {
            return $"{product.IdProduct};{product.Name};{product.Description};{product.Price}";
        }

        /// <summary>
        /// Lista todos os produtos
        /// </summary>
        /// <returns>Retorna uma lista de produtos</returns>
        public List<Product> ReadAll()
        {
            List<Product> products = new();

            string[] lines = File.ReadAllLines(path);

            foreach (var item in lines)
            {
                string[] line = item.Split(";");

                Product product = new()
                {
                    IdProduct = line[0],
                    Name = line[1],
                    Description = line[2],
                    Price = Convert.ToDecimal(line[3])
                };

                products.Add(product);
            }

            return products;
        }

        /// <summary>
        /// Cadastra um novo produto
        /// </summary>
        /// <param name="product">Objeto com os dados de cadastro</param>
        public void Create(Product product)
        {
            string[] line = { PrepareLine(product) };
            File.AppendAllLines(path, line);
        }

        /// <summary>
        /// Edita um produto existente
        /// </summary>
        /// <param name="product">Objeto com os novos dados</param>
        public void Update(Product product)
        {
            List<string> lines = ReadAllLinesCSV(path);
            lines.RemoveAll(x => x.Split(";")[0] == product.IdProduct);
            lines.Add(PrepareLine(product));
            RewriteCSV(path, lines);
        }

        /// <summary>
        /// Deleta um produto existente
        /// </summary>
        /// <param name="idProduct">Código do produto que será deletado</param>
        public void Delete(string idProduct)
        {
            List<string> lines = ReadAllLinesCSV(path);
            lines.RemoveAll( x => x.Split(";")[0] == idProduct );
            RewriteCSV(path, lines);
        }
    }
}
