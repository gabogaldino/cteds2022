using parallel_program.Models;

namespace parallel_program.Interfaces
{
    /// <summary>
    /// Interface com as operações básicas de manipulação de arquivo
    /// </summary>
    internal interface IProduct
    {
        List<Product> ReadAll();

        void Create(Product product);

        void Update(Product product);

        void Delete(string idProduct);
    }
}
