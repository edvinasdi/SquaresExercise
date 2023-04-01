using Microsoft.AspNetCore.Mvc;
using SquaresAPI.Models;

namespace SquaresAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly IWebHostEnvironment env;

        public StatusController(IWebHostEnvironment env)
        {
            this.env = env;
        }
        
        [HttpGet(Name = "GetStatus")]
        public ActionResult GetStatus()
        {
            return Ok(new Status()
            {
                Environment = env.EnvironmentName,
            });
        }
    }
}
