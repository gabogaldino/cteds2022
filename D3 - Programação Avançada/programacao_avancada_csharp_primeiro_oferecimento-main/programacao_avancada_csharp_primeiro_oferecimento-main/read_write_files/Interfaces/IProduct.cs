using read_write_files.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace read_write_files.Interfaces
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
