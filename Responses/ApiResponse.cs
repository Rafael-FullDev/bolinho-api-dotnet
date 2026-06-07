namespace ASP.NET_Core_Web_API.Responses;

public class ApiResponse<T>
{
    public bool Sucesso { get; set; }

    public string Mensagem { get; set; } = string.Empty;

    public T? Dados { get; set; }

    public List<string>? Erros { get; set; }

    public static ApiResponse<T> SucessoResponse(T dados, string mensagem)
    {
        return new ApiResponse<T>
        {
            Sucesso = true,
            Mensagem = mensagem,
            Dados = dados,
            Erros = null
        };
    }

    public static ApiResponse<T> ErroResponse(string mensagem, List<string>? erros = null)
    {
        return new ApiResponse<T>
        {
            Sucesso = false,
            Mensagem = mensagem,
            Dados = default,
            Erros = erros
        };
    }
}