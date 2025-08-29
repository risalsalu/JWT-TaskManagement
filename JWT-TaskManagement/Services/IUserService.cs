using JWT_TaskManagement.Models;

namespace TaskApiDemo.Services
{
    public interface IUserService
    {
        User? ValidateUser(string username, string password);
        User Register(string username, string password, string role);
    }
}
