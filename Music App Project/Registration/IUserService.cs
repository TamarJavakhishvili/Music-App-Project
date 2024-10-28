using Music_App_Project.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_App_Project
{
    public interface IUserService
    {
        void RegisterUser(string name, string lastname, string username, string password, string email);
        bool Login(string username, string password);
        void ViewAllUsers();
        void DeleteUser(int id);
        void CheckBalance(string username);
        void FillBalance(string username);
        void MakePayment(string username);

    }
}
