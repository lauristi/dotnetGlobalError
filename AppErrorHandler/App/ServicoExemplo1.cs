using AppErrorHandler.Service;

namespace AppErrorHandler.App
{
    public class ServicoExemplo1
    {
        private readonly IErrorHandlingService errorHandlingService;

        public ServicoExemplo1(IErrorHandlingService errorHandlingService)
        {
            this.errorHandlingService = errorHandlingService;
        }

        public void DoSomething()
        {
            try
            {
                // Código que pode gerar exceções
            }
            catch (Exception ex)
            {
                var json = errorHandlingService.HandleError(ex);
                // Faça algo com o JSON
            }
        }
    }
}