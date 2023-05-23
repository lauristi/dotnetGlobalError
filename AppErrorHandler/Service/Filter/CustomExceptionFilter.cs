using Microsoft.AspNetCore.Mvc.Filters;

namespace AppErrorHandler.Service.Filter
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly IErrorHandlingService errorHandlingService;

        public CustomExceptionFilter(IErrorHandlingService errorHandlingService)
        {
            this.errorHandlingService = errorHandlingService;
        }

        public void OnException(ExceptionContext context)
        {
            // Capturar a exceção e gerar a resposta de erro em formato JSON
            var jsonResponse = errorHandlingService.HandleError(context.Exception);

            // Configurar a resposta HTTP com o JSON de erro
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = 500; // Código de status de erro interno do servidor
            context.Result = new JsonResult(jsonResponse);
        }
    }
}