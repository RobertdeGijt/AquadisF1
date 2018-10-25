using AquadisF1.DAL.Interface;
using AquadisF1.Model.Models;

namespace AquadisF1.DAL.MSSQL
{
    public class AccountMSSQLContext : IAccountContext
    {
        private readonly string _connectionString;

        public AccountMSSQLContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public bool Create(User entity)
        {
            throw new System.NotImplementedException();
        }

        public User Read(int id)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
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