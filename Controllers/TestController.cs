using Microsoft.AspNetCore.Mvc;

namespace DatingAPI.Controllers
{
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult ItWorks()
        {
            return Ok(new
            {
                DoesItWork = "Yes",
                AppName = "DatingYou",
                Dev = "Enea",
                Hotel = "Trivago"
            });
        }
    }
}