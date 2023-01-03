using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksAPI.Domains;

[Table("Authors")]
public class Author
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AuthorId { get; set; }

    [Column(TypeName = "VARCHAR(150)")]
    [Required(ErrorMessage = "O nome do autor é obrigatório!")]
    public string Name { get; set; } = string.Empty;

    [Column(TypeName = "VARCHAR(150)")]
    public string Birthdate { get; set; } = string.Empty;

    [Column(TypeName = "VARCHAR(150)")]
    public string Deathdate { get; set; } = string.Empty;

    public ICollection<Book>? Books { get; set; }
}
