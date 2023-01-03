using acessing_db.Models;
using acessing_db.Repositories;

namespace acessing_db
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductRepository _product = new();

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
                            var productList = _product.ReadAll();

                            Console.WriteLine("\nLista de produtos:");

                            foreach (var item in productList)
                            {
                                Console.WriteLine($"{item.IdProduct} - {item.Name} - {item.Description} - R${item.Price}");
                            }
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

                    case "3":
                        Console.WriteLine("\nDigite o código do produto que será alterado:");
                        var idEdited = Console.ReadLine();
                        Console.WriteLine("\nDigite o novo nome do produto:");
                        var nameEdited = Console.ReadLine();
                        Console.WriteLine("\nDigite a descrição do produto:");
                        var descriptionEdited = Console.ReadLine();
                        Console.WriteLine("\nDigite o preço do produto (somente valores):");
                        var priceEdited = Convert.ToDecimal(Console.ReadLine());

                        Product productEdited = new()
                        {
                            IdProduct = idEdited,
                            Name = nameEdited,
                            Description = descriptionEdited,
                            Price = Convert.ToDecimal(priceEdited)
                        };

                        _product.Update(productEdited);
                        break;

                    case "4":
                        Console.WriteLine("\nDigite o código do produto que será deletado:");
                        var idRemoved = Console.ReadLine();

                        _product.Delete(idRemoved);
                        break;

                    default:
                        break;
                }

            } while (option != "0");
        }
    }
}