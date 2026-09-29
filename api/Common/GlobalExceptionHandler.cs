using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace api.Common
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;
        private readonly IProblemDetailsService _problemDetailsService;
        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, IProblemDetailsService problemDetailsService)
        {
            _logger = logger;
            _problemDetailsService = problemDetailsService;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken) {
            ProblemDetails p = new ProblemDetails();
            p.Instance = httpContext.Request.Path;
            if (exception is AppException appEx)
            {
                
                p.Status = appEx.StatusCode;
                p.Detail = appEx.Message;
                

            }
            else
            {
                p.Status = 500;
                p.Detail = "Ocurrio un error inesperado";
                _logger.LogError(exception, "Error inesperado procesando {Path}", httpContext.Request.Path);

            }
            httpContext.Response.StatusCode = p.Status.Value;
            return await _problemDetailsService.TryWriteAsync(new ProblemDetailsContext
            {
                HttpContext = httpContext,
                ProblemDetails = p
            });
        }
    }
}
