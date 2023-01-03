using parallel_program.Models;
using parallel_program.Repositories;

namespace parallel_program
{
    internal class Program
    {
        private const string path = "database/log.txt";

        static void Main(string[] args)
        {
            ProductRepository _product = new();

            //_product.LoadData();

            FileStream fileStream = File.OpenWrite(path);

            LogRepository _log = new(fileStream);

            User user = new()
            {
                Name = "Anderson Pessoa",
                JobTitle = "Developer"
            };

            string option;

            do
            {
                Console.WriteLine("\nEscolha uma das opções abaixo:\n");
                Console.WriteLine("1 - Listar produtos");
                Console.WriteLine("2 - Cadastrar produto");
                Console.WriteLine("3 - Editar produto");
                Console.WriteLine("4 - Excluir produto");
                Console.WriteLine("0 - Sair da aplicação\n");

                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        if (_product.ReadAll().Count == 0)
                        {
                            Console.WriteLine("\nNão há nenhum produto cadastrado!\n");
                        }
                        else
                        {
                            //var productList = _product.ReadAll();

                            //Console.WriteLine("\nLista de produtos:");

                            //foreach (var item in productList)
                            //{
                            //    Console.WriteLine($"{item.IdProduct} - {item.Name} - {item.Description} - R${item.Price}");
                            //}

                            var productList = _product.ReadAll();

                            Parallel.ForEach(productList, product =>
                            {
                                Console.WriteLine($"\nO usuário: {user.Name} está exibindo o produto: \n{product.IdProduct} - {product.Name} \nutilizando a Thread: {Thread.CurrentThread.ManagedThreadId} às {DateTime.Now}");
                                _log.RegisterAccess(user);
                            });

                            //foreach (var product in productList)
                            //{
                            //    Console.WriteLine($"\nO usuário: {user.Name} está exibindo o produto: \n{product.IdProduct} - {product.Name} \nutilizando a Thread: {Thread.CurrentThread.ManagedThreadId} às {DateTime.Now}");
                            //    _log.RegisterAccess(user);
                            //}
                        }
                        break;

                    case "2":
                        Console.WriteLine("\nDigite o código do produto:\n");
                        var id = Console.ReadLine();
                        Console.WriteLine("Digite o nome do produto:\n");
                        var name = Console.ReadLine();
                        Console.WriteLine("Digite a descrição do produto:\n");
                        var description = Console.ReadLine();
                        Console.WriteLine("Digite o preço do produto:\n");
                        var price = Console.ReadLine();

                        Product newProduct = new()
                        {
                            IdProduct = id,
                            Name = name,
                            Description = description,
                            Price = Convert.ToDecimal(price)
                        };

                        _product.Create(newProduct);
                        break;

                    case "4":
                        Console.WriteLine("Digite o código do produto que será deletado:");
                        var idRemoved = Console.ReadLine();

                        _product.Delete(idRemoved);
                        break;

                    default:
                        break;
                }

            } while (option != "0");

            fileStream.Close();
        }
    }
}