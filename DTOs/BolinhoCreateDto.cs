using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Core_Web_API.DTOs;

public class BolinhoCreateDto
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "A descrição é obrigatória.")]
    [StringLength(300, ErrorMessage = "A descrição deve ter no máximo 300 caracteres.")]
    public string Descricao { get; set; } = string.Empty;

    public bool Pronto { get; set; } = true;
}