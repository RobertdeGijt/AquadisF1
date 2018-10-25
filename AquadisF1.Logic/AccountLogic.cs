using AquadisF1.DAL.Interface;
using AquadisF1.Logic.Interface;
using AquadisF1.Model.Models;

namespace AquadisF1.Logic
{
    public class AccountLogic : IAccountLogic
    {
        private readonly IAccountContext _context;

        public AccountLogic(IAccountContext repository)
        {
            _context = repository;
        }
        
        public bool Create(User entity)
        {
            if (entity.Password == null || entity.Email == null)
            {
                return false;
            }
            if (entity.Email.Length >= 5 && entity.Email.Contains('@') && entity.Password.Length >= 6)
            {
                entity.Password = BCrypt.Net.BCrypt.HashPassword(entity.Password);
                return _context.Create(entity);
            }
            return false;
        }

        public User Read(int id)
        {
            if (id < 1)
            {
                return null;
            }

            return _context.Read(id);
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
            if (email == null || password == null)
            {
                return false;
            }

            if(email.Length >= 5 && email.Contains('@') && password.Length >= 6)
            {
                return _context.Login(email, password);
            }
            return false;
        }

        public User GetProfile(int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}