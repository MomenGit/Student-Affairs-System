using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ErrorController : ControllerBase
{
    [HttpGet]
    public ActionResult<string> Get()
    {
        IExceptionHandlerFeature? context = HttpContext.Features.Get<IExceptionHandlerFeature>();
        Exception exception = context!.Error;
        string message = exception.Message;
        string? stackTrace = exception.StackTrace;

        return Problem();
    }
}