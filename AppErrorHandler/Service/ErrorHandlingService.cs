using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppErrorHandler.Service
{
    public class ErrorHandlingService : IErrorHandlingService
    {
        public string HandleError(Exception ex)
        {
            var error = new ErrorDetails
            {
                ErrorType = ex.GetType().Name,
                ErrorMessage = ex.Message
            };

            var json = JsonConvert.SerializeObject(error);
            return json;
        }
    }
}
