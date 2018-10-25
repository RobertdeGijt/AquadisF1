using AquadisF1.Model.Models;

namespace AquadisF1.Logic.Interface
{
    public interface IAccountLogic : ILogic<User>
    {
        bool Login(string email, string password);
        User GetProfile(int userId);
    }
}