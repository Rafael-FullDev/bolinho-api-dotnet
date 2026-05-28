namespace ASP.NET_Core_Web_API.Models
{
    public class bolinho
    {
        public int  Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descrição { get; set; } = string.Empty;
        public bool Pronto { get; set; }
    }
}
