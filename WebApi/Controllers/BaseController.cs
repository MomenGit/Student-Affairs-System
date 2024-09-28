using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Shared.UnitOfWork;

namespace WebApi.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class BaseController : ControllerBase
{
    protected readonly IUnitOfWork _unitOfWork;

    public BaseController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}