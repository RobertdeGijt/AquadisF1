using System.Collections.Generic;
using System.Linq;
using AquadisF1.DAL.Interface;
using AquadisF1.Model.Models;

namespace AquadisF1.DAL.Memory
{
    public class AccountMemoryContext : IAccountContext
    {
        private List<User> _users;

        public AccountMemoryContext()
        {
            _users = new List<User>();
            _users.Add(new User()
            {
                Id = 1,
                Email = "aquadis@aquadis.com",
                Password = "123456789"
                
            });
        }
        public bool Create(User entity)
        {
            entity.Id = 2;
            _users.Add(entity);
            return true;
        }

        public User Read(int id)
        {
            return _users.SingleOrDefault(x => x.Id == id);
        }

        public bool Update(User entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Login(string email, string password)
        {
            return _users.SingleOrDefault(x => x.Email == email && x.Password == password) != null;
        }

        public bool Exists(string email)
        {
            throw new System.NotImplementedException();
        }

        public User GetCookieInfo(string email)
        {
            throw new System.NotImplementedException();
        }
    }
}