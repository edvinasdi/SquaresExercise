using Microsoft.AspNetCore.Mvc;
using SquaresAPI.Data.Repositories;
using SquaresAPI.Models;

namespace SquaresAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        private readonly IDatabaseStatusRepository _databaseStatusRepostory;

        public StatusController(IWebHostEnvironment env, IDatabaseStatusRepository databaseStatusRepostory)
        {
            this._env = env;
            _databaseStatusRepostory = databaseStatusRepostory;
        }

        [HttpGet("/status")]
        public ActionResult GetStatus()
        {
            return Ok(new Status()
            {
                Environment = _env.EnvironmentName,
                DatabaseStatus = _databaseStatusRepostory.CanConnect() ? "all good" : "woops, something's not right",
            });
        }
    }
}
