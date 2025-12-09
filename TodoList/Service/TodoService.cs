using MongoDB.Driver;
using System.Security.Cryptography.X509Certificates;
using TodoList.Models;

namespace TodoList.Service
{
    public class TodoService
    {
        private readonly IMongoCollection<TodoItem> _todoCollection;
        public TodoService(IConfiguration configuration)
        {
            var connectionString = configuration["MongoDB:ConnectionString"];
            var databaseName = configuration["MongoDB:Database"];

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);

            _todoCollection = database.GetCollection<TodoItem>("TodoItems");
        }

        public async Task<List<TodoItem>> GetAllAsync()
        {
            return await _todoCollection.Find(_ => true).ToListAsync();
        }
        // Получение задачи по идентификатору
        public async Task<TodoItem> GetByIdAsync(string id)
        {
            return await _todoCollection.Find(item => item.Id == id).FirstOrDefaultAsync();
        }
        // Создание новой задачи
        public async Task CreateAsync(TodoItem todoItem)
        {
             await _todoCollection.InsertOneAsync(todoItem);
        }
        // Обновление задачи по идентификатору
        public async Task UpdateAsync(string id, TodoItem updatedItem)
        {
            await _todoCollection.ReplaceOneAsync(item => item.Id == id, updatedItem);
        }
        // Удаление задачи по идентификатору
        public async Task DeleteAsync(string id)
        {
            await _todoCollection.DeleteOneAsync(item => item.Id == id);
        }

    }
}
