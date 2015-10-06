using System.Collections.Generic;
using System.Linq;
using Becky.Data;
using Becky.Data.DataAccess;
using Becky.Task.Interface;

namespace Becky.Task.Task
{
    public class UserTask : TaskBase, IUserTask
    {
        private readonly IRepository<User> _userRepository;
        public UserTask(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public IList<User> GetUsers() => _userRepository.GetAll().ToList();

        public User GetUser(int id)
        {
            return _userRepository.FirstOrDefault(p => p.Id == id);
        }

        public void AddUser(User user)
        {
            _userRepository.Insert(user);
            _userRepository.SaveChanges();
        }

        public void RemoveUser(int id)
        {
            var user = _userRepository.FirstOrDefault(p => p.Id == id);

            if (user != null)
            {
                _userRepository.Delete(user);
                _userRepository.SaveChanges();
            }
        }
    }
}