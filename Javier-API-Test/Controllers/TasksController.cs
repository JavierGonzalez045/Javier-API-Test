using Javier_API_Test.Models;
using Javier_API_Test.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Javier_API_Test.Controllers
{
    /*
     This section is in charge of the requests, 
     creation of tasks, update, deletion and validation of the requests
     */

    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ToDo>> GetTasks()
        {
            return await _taskRepository.Get();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ToDo>> GetTasks(Guid Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            return await _taskRepository.Get(Id);
        }

        [HttpPost]
        public async Task<ActionResult<ToDo>> PostTasks([FromBody] ToDo task)
        {
            var newTask= await _taskRepository.Create(task);
            return CreatedAtAction(nameof(GetTasks), new { id = newTask.Id }, newTask);
        }

        [HttpPatch]
        public async Task<ActionResult> PutTasks(Guid id, [FromBody] ToDo task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            await _taskRepository.Update(task);

            return NoContent();
        }
    }
}
