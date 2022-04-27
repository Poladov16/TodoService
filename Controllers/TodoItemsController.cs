using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApiDTO.Business.Models.Dto;
using TodoApiDTO.Business.Services;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {

        private readonly ITodoService _service;
        private readonly ILogger _logger;
        private readonly ILogger<ControllerBase> _nlogger;
        public TodoItemsController(ITodoService service, ILogger logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetTodoItems()
        {
            try
            {
                return Ok(await _service.GetAllAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetAllAsync: Exception: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItemDto>> GetTodoItem(long id)
        {

            var todoItem = await _service.GetAsync(id);

            if (todoItem == null)
            {
                _logger.LogInformation("todoItem is null");
                _logger.LogError($"GetTodoItem: Id Not Found id={id}.");
                return NotFound();
            }

            return Ok(todoItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItem(long id, ToDoItemDto todoItemDTO)
        {

            try
            {
                if (id != todoItemDTO.Id)
                {
                    return BadRequest("ID mismatch");
                }
                var result = await _service.UpdateAsync(id, todoItemDTO);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"UpdateTodoItem: Exception Result :{ex.Message}.");

                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<ToDoItemDto>> CreateTodoItem(ToDoItemDto todoItemDTO)
        {
            try
            {
                var todoItem = await _service.AddAsync(todoItemDTO);
                return CreatedAtAction(
                    nameof(GetTodoItem),
                    todoItem
                    );
            }
            catch (Exception ex)
            {
                _logger.LogError($"CreateTodoItem: Exception Result :{ex.Message}.");
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            try
            {
                await _service.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"DeleteTodoItem: Exception Result :{ex.Message}.");

                return NotFound();
            }

        }

    }
}
