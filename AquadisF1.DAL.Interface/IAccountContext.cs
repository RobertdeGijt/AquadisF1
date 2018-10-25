using AquadisF1.Model.Models;

namespace AquadisF1.DAL.Interface
{
    public interface IAccountContext : IContext<User>
    {
        bool Login(string email, string password);
    }
}