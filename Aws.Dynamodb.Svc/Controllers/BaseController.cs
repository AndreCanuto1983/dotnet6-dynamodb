using Aws.Dynamodb.Svc.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aws.Dynamodb.Svc.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult ProcessResponse(IResponseBase response)
        {
            switch (response.StatusCode)
            {
                case StatusCodes.Status200OK:
                    return Ok(response);

                case StatusCodes.Status201Created:
                    return Created(string.Empty, string.Empty);

                case StatusCodes.Status204NoContent:
                    return NoContent();

                case StatusCodes.Status400BadRequest:
                    return new BadRequestObjectResult(response);

                case StatusCodes.Status404NotFound:
                    return NotFound(response);

                case StatusCodes.Status500InternalServerError:
                    return StatusCode(StatusCodes.Status500InternalServerError, response);

                case StatusCodes.Status503ServiceUnavailable:
                    return StatusCode(StatusCodes.Status503ServiceUnavailable, response);

                default:
                    return StatusCode(StatusCodes.Status502BadGateway, response);
            }
        }
    }
}
