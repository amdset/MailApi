using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MailApi.Controllers;

[Route("/")]
[ApiController]
public class RootController : ControllerBase
{
    [HttpGet(Name = nameof(GetRoot))]
    public IActionResult GetRoot()
    {
        var routes =new
        {
            href = Url.Link(nameof(GetRoot), null),
            email = new
            {
                href = Url.Link(nameof(EmailController.Get), null)
            }
        };

        return Ok(routes);
    }
}
