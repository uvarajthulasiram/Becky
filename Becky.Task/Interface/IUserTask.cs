using System.Collections.Generic;
using Becky.Data;

namespace Becky.Task.Interface
{
    public interface IUserTask
    {
        IList<User> GetUsers();
        User GetUser(int id);
        void AddUser(User user);
        void RemoveUser(int id);
    }
}