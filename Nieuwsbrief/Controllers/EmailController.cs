using Microsoft.AspNetCore.Mvc;

namespace Nieuwsbrief.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController(EmailContext context, IConfiguration config, HttpClient client) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(String emailString)
        {
            var apiKey = config["AbstracAPIKey"];

            if (apiKey != null) 
            {
                var response = await client.GetAsync($"https://emailvalidation.abstractapi.com/v1/?api_key={apiKey}&email={emailString}");
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var jsonObject = System.Text.Json.JsonDocument.Parse(jsonResponse);

                if (jsonObject == null || jsonObject.RootElement.GetProperty("deliverability").ToString() == "UNDELIVERABLE")
                {
                    return BadRequest("Invalid email");
                }
            }

            if (context.Emails.Any(email => email.EmailAddress == emailString))
            {
                return BadRequest("Email already subscribed");
            }

            var email = new Email { EmailAddress = emailString };

            context.Add(email);
            await context.SaveChangesAsync();

            return Created();
        }
    }
}
