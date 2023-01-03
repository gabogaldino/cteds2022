namespace parallel_program.Models
{
    /// <summary>
    /// Propriedades que definem um produto
    /// </summary>
    internal class Product
    {
        public string IdProduct { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }
    }
}
