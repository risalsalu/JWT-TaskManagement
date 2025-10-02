using JWT_TaskManagement.Models;

namespace TaskApiDemo.Services
{
    public interface ITaskService
    {
        TaskItem Creat(TaskItem task);
        IEnumerable<TaskItem> GetAll();
        TaskItem? GetById(int id);
        bool Update(int id, TaskItem task);
        bool Delete(int id);
    }
}
