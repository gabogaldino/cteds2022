using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamesAPI.Domains;

[Table("Studios")]
public class Studio
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdStudio { get; set; }

    [Column(TypeName = "VARCHAR(150)")]
    [Required(ErrorMessage = "O nome do estúdio é obrigatório!")]
    public string StudioName { get; set; } = string.Empty;
}
