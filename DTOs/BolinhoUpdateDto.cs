using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Core_Web_API.DTOs;

public class BolinhoUpdateDto
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "A descrição é obrigatória.")]
    [StringLength(300, ErrorMessage = "A descrição deve ter no máximo 300 caracteres.")]
    public string Descricao { get; set; } = string.Empty;

    public bool Pronto { get; set; }

    [Required(ErrorMessage = "A categoria é obrigatória.")]
    [StringLength(80, ErrorMessage = "A categoria deve ter no máximo 80 caracteres.")]
    public string Categoria { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "A URL da imagem deve ter no máximo 500 caracteres.")]
    public string ImagemUrl { get; set; } = string.Empty;
}