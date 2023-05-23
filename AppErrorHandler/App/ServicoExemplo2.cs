using Microsoft.AspNetCore.Http;

public class ServicoExemplo2
{
    private readonly HttpClient _httpClient;

    public ServicoExemplo2(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task ExecuteAsync(HttpContext context)
    {
        try
        {
            // Faz a solicitação HTTP para o endereço externo
            HttpResponseMessage response = await _httpClient.GetAsync("https://bancos/lista");

            // Verifica se a resposta foi bem-sucedida
            if (response.IsSuccessStatusCode)
            {
                // Lê o conteúdo da resposta como uma string
                string responseBody = await response.Content.ReadAsStringAsync();

                // Do something....
            }
            else
            {
                // Se a resposta não foi bem-sucedida, lança uma exceção HTTP
                // Que será capturada pelo middleware
                response.EnsureSuccessStatusCode();
            }
        }
        catch (Exception ex)
        {
            // O tratamento de erros será realizado
            // pelo middleware ErrorHandlingMiddleware
            
            throw;
        }
    }
}