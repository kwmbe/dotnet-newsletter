using Microsoft.AspNetCore.Mvc;

namespace Nieuwsbrief.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController(EmailContext context) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(String emailString)
        {
            // validate first

            var email = new Email { EmailAddress = emailString };

            context.Add(email);
            await context.SaveChangesAsync();

            return Created();
        }
    }
}
