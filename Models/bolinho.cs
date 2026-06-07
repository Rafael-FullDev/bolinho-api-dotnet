namespace ASP.NET_Core_Web_API.Models
{
    public class Bolinho
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public bool Disponivel { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public string ImagemUrl { get; set; } = string.Empty;
    }
}
