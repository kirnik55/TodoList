using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using ZstdSharp;

namespace TodoList.Controllers
{

    [ApiController]
    [Route("todos")]
    public class TodoController : ControllerBase
    {
        private readonly Service.TodoService _todoService;

        public TodoController(Service.TodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var item = await _todoService.GetAllAsync();
            return Ok(item);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActionAsync(string id)
        {
            var item = await _todoService.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound("Задача с указанным ID не найдена.");
            }
            return Ok(item);
        }
        [HttpPost("CreateTask")]
        public async Task<IActionResult> CreateAsync([FromBody] TodoItem todoItem)
        {
            await _todoService.CreateAsync(todoItem);
            return Ok($"Задача {todoItem} успешно создана");

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(string id, [FromBody] TodoItem updatedItem)
        {
            var existingItem = await _todoService.GetByIdAsync(id);
            if (existingItem == null)
            {
                return NotFound("Задача с указанным ID не найдена.");
            }
            await _todoService.UpdateAsync(id, updatedItem);
            return Ok($"Задача с ID {id} успешно обновлена.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var deleteItem = await _todoService.GetByIdAsync(id);
            if (deleteItem == null)
            {
                return NotFound($"Задача с указанным {id} не найдена");
            }
            await _todoService.DeleteAsync(id);
            return Ok($"Заметка с {id} успешно удалена");

        }

    }
}
