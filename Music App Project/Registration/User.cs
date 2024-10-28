using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Music_App_Project.Registration
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        private double _userBalance { get; set; }

       
        public override string ToString()
        {
            return $"Name: {Name}, Lastname: {LastName}, Username: {UserName}, Email: {Email}, ID: {Id} ";
        }

        public double GetBalance()
        {
            return _userBalance;
        }

        public void SetBalance(double balance)
        { 
            _userBalance = balance;
        }

       


    }
}
