using read_write_files.Models;

namespace read_write_files
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product = new();

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
                        if (product.ReadAll().Count == 0)
                        {
                            Console.WriteLine("\nNão há nenhum produto cadastrado!\n");
                        }
                        else
                        {
                            var productList = product.ReadAll();

                            Console.WriteLine("\nLista de produtos:");

                            foreach (var item in productList)
                            {
                                Console.WriteLine( $"{item.IdProduct} - {item.Name} - {item.Description} - R${item.Price}" );
                            }
                        }
                        break;

                    case "2":
                        Console.WriteLine("\nDigite o código do produto:");
                        var id = Console.ReadLine();
                        Console.WriteLine("\nDigite o nome do produto:");
                        var name = Console.ReadLine();
                        Console.WriteLine("\nDigite a descrição do produto:");
                        var description = Console.ReadLine();
                        Console.WriteLine("\nDigite o preço do produto:");
                        var price = Console.ReadLine();

                        Product newProduct = new()
                        {
                            IdProduct = id,
                            Name = name,
                            Description = description,
                            Price = Convert.ToDecimal(price)
                        };

                        product.Create(newProduct);
                        break;

                    case "3":
                        Console.WriteLine("\nDigite o código do produto que será alterado:");
                        var idEdited = Console.ReadLine();
                        Console.WriteLine("\nDigite o novo nome do produto:");
                        var nameEdited = Console.ReadLine();
                        Console.WriteLine("\nDigite a descrição do produto:");
                        var descriptionEdited = Console.ReadLine();
                        Console.WriteLine("\nDigite o preço do produto (somente valores):");
                        var priceEdited = Console.ReadLine();

                        Product productEdited = new()
                        {
                            IdProduct = idEdited,
                            Name = nameEdited,
                            Description = descriptionEdited,
                            Price = Convert.ToDecimal(priceEdited)
                        };

                        product.Update(productEdited);
                        break;

                    case "4":
                        Console.WriteLine("\nDigite o código do produto que será deletado:");
                        var idRemoved = Console.ReadLine();

                        product.Delete(idRemoved);
                        break;

                    default:
                        break;
                }

            } while (option != "0");
        }
    }
}