using Microsoft.AspNetCore.Mvc;

namespace WebAPIForHousing.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/[controller]")]
    [ApiController]

    public class BaseController : ControllerBase
    {
      
    }
}
