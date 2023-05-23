using AppErrorHandler.Service;
using AppErrorHandler.Service.Filter;
using Microsoft.Extensions.DependencyInjection;

void ConfigureServices(IServiceCollection services)
{
    // Outras configurações de serviços...

    services.AddScoped<IErrorHandlingService, ErrorHandlingService>();

    // Outras configurações de serviços...

    services.AddMvcCore(options =>
    {
        options.Filters.Add<CustomExceptionFilter>();
    });
}