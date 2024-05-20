using MextFullStack.Persistance.Services;
using MextFullStack.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MextFullStack.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RootPathsController : ControllerBase
    {
        private readonly IRootPathService _roodPathService;

        public RootPathsController(IRootPathService roodPathService)
        {
            _roodPathService = roodPathService;
        }

        [HttpGet]
        public IActionResult GetRootPath()
        {
            return Ok(_roodPathService.GetRootPath());
        }

        [HttpPost]
        public IActionResult SaveCountsToRootPath()
        {
            _roodPathService.WriteTotalCount();
            return Ok("Totalcounts have been succesfully written.");
        }
    }
}
