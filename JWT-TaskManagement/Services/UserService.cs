using JWT_TaskManagement.Models;
using System.Collections.Concurrent;

namespace TaskApiDemo.Services
{
    public class UserService : IUserService
    {
        private readonly ConcurrentDictionary<string, User> _users = new();

        public UserService()
        {
            // Default Admin
            _users.TryAdd("admin", new User
            {
                Username = "admin",
                Password = "admin123",
                Role = "Admin"
            });

            // Default User
            _users.TryAdd("user", new User
            {
                Username = "user",
                Password = "user123",
                Role = "User"
            });
        }

        public User? ValidateUser(string username, string password)
        {
            if (_users.TryGetValue(username, out var user))
            {
                if (user.Password == password)
                    return user;
            }
            return null;
        }

        public User Register(string username, string password, string role)
        {
            var user = new User { Username = username, Password = password, Role = role };
            _users.TryAdd(username, user);
            return user;
        }
    }
}
