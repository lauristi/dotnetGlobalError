using AppErrorHandler.Service;
using Microsoft.AspNetCore.Http;

namespace AppErrorHandler.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IErrorHandlingService errorHandlingService;

        public ErrorHandlingMiddleware(RequestDelegate next, IErrorHandlingService errorHandlingService)
        {
            this.next = next;
            this.errorHandlingService = errorHandlingService;
        }

        // Função Invoke é um método padrão que os middlewares
        // devem implementar para processar uma requisição HTTP e interagir
        // com o próximo middleware na pipeline.
        // O Invoke é responsável por receber o contexto da requisição, executar
        // a lógica do middleware e, se necessário, chamar o próximo middleware na cadeia de execução.

        public async Task Invoke(HttpContext context)
        {
            try
            {
                // Chama o próximo middleware no pipeline
                await next(context);
            }
            catch (Exception ex)
            {
                // Captura a exceção ocorrida

                // Utiliza o serviço de tratamento de erros para obter o JSON com as informações do erro
                var json = errorHandlingService.HandleError(ex);

                // Faça algo com o JSON, como retorná-lo como resposta HTTP ou registrar em logs
                // Você pode adicionar aqui a lógica específica para tratar o erro, como retornar uma resposta de erro personalizada

                // Por exemplo, para retornar uma resposta HTTP com o JSON de erro:
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500; // Código de status de erro interno do servidor
                await context.Response.WriteAsync(json);
            }
        }
    }
}