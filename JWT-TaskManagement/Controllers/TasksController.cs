using JWT_TaskManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskApiDemo.Services;

namespace TaskApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService) => _taskService = taskService;

        // Create - User or Admin
        [HttpPost]
        [Authorize(Roles = "User,Admin")]
        public IActionResult Create([FromBody] TaskItem req)
        {
            if (string.IsNullOrWhiteSpace(req.Title))
                return BadRequest(new { message = "Title required" });

            var created = _taskService.Create(req);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // Read all - User or Admin
        [HttpGet]
        [Authorize(Roles = "User,Admin")]
        public IActionResult GetAll() => Ok(_taskService.GetAll());

        // Read by id - User or Admin
        [HttpGet("{id:int}")]
        [Authorize(Roles = "User,Admin")]
        public IActionResult GetById(int id)
        {
            var t = _taskService.GetById(id);
            if (t == null) return NotFound();
            return Ok(t);
        }

        // Update - User or Admin
        [HttpPut("{id:int}")]
        [Authorize(Roles = "User,Admin")]
        public IActionResult Update(int id, [FromBody] TaskItem req)
        {
            var ok = _taskService.Update(id, req);
            if (!ok) return NotFound();
            return NoContent();
        }

        // Delete - Admin only
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var ok = _taskService.Delete(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
