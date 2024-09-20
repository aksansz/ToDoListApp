using Microsoft.AspNetCore.Mvc;
using ToDoListApp.Interfaces;
using ToDoListApp.Models;

namespace ToDoListApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlannerController : ControllerBase
    {
        private readonly IPlannerService? plannerService;

        public PlannerController(IPlannerService _plannerService)
        {
            plannerService = _plannerService;
        }

        [HttpPost("generate-subtasks")]
        public async Task<IActionResult>GenerateSubtasks([FromBody] AiRequest request)
        {
            var response = await plannerService.GenerateSubtasks(request);
            if(response.Successful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}