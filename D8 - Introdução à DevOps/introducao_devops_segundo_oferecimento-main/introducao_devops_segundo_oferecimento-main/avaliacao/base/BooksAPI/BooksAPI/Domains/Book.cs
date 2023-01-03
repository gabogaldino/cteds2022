using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksAPI.Domains;

[Table("Books")]
public class Book
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BookId { get; set; }

    [Column(TypeName = "VARCHAR(150)")]
    [Required(ErrorMessage = "O nome do livro é obrigatório!")]
    public string Name { get; set; } = string.Empty;

    [Column(TypeName = "VARCHAR(4)")]
    public string PublicationYear { get; set; } = string.Empty;

    [Column(TypeName = "VARCHAR(10)")]
    public string Pages { get; set; } = string.Empty;


    public int AuthorId { get; set; }

    [ForeignKey("AuthorId")]
    public Author? Author { get; set; }
}
