using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Serie
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome do usuário é obrigatório")]
    [MaxLength(10, ErrorMessage = "O tamanho máximo são 10 caracteres")]
    public string NomeUsuario { get; set; }
    
    [Required(ErrorMessage = "Titulo obrigatório")]
    [MaxLength(15, ErrorMessage = "O tamanho máximo são 15 caracteres")]
    public string Titulo { get; set; }
    
    [Required(ErrorMessage = "A nota é obrigatória")]
    [Range(0,5, ErrorMessage = "A avaliação deve ser entre 0 e 5")]
    public int Avaliacao { get; set; }

}