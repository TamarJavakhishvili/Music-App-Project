using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_App_Project.Registration
{
    public class UserService: User, IUserService
    {
        private List<User> users = new List<User>();  

        public UserService()
        {
            users.Add(new User
            {
                Id = 1,
                Name = "Tamar",
                LastName = "Javakhishvili",
                UserName = "Tamunaj",
                Password = "Tamuna1*",
                Email = "tamuna@gmail.com",

            });

            users.Add(new User
            {
                Id = 2,
                Name = "Nika",
                LastName = "Chachanidze",
                UserName = "Nika123",
                Password = "Nika123*",
                Email = "nika@gmail.com",

            });
        }

        public void RegisterUser(string name, string lastname, string username, string password, string email)
        {
            try
            {
                if (users.Any(x => x.UserName == username))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Username already exists. Please choose another one.");
                    Console.ResetColor();
                    return;
                }

                int newId = users.Count > 0 ? users.Max(x => x.Id) + 1 : 1;  
                users.Add(new User { Id = newId, Name = name, LastName = lastname, UserName = username, Password = password, Email = email });
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"User '{username}' registered succesfully.");
                Console.ResetColor();
                Console.WriteLine("          ");
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error: " + ex.Message);
            }
        }

        
        public bool Login(string username, string password)
        {
            try
            {
                User user = users.FirstOrDefault(x => x.UserName == username && x.Password == password);

                if (user != null)
                {
                    //Console.WriteLine($"Welcome {user.Name}, you have logged in successfully.");
                    return true;
                }
                else
                {
                    //Console.WriteLine("Invalid username or password.");
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ViewAllUsers()
        {
            try
            {
                Console.WriteLine("Music app User List:");
                foreach (var user in users)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(user);
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void DeleteUser(int id)
        {
            try
            {
                User user = users.FirstOrDefault(x => x.Id == id);

                if (user != null)
                {
                    users.Remove(user);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"User with Id {id} deleted successfully.");  
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("user not found!");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error: " + ex.Message);
            }
        }
                  
       
        public void CheckBalance(string username)
        {
            try
            {
                var user = users.FirstOrDefault(x => x.UserName == username);
                if (user != null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"Your current balance is {user.GetBalance()} $.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("User not found!");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

      
        public void FillBalance(string username)
        {
            try
            {
                var user = users.FirstOrDefault(x => x.UserName == username);
                if (user != null)
                {
                    Console.Write("Enter the amount to add: ");
                    double amountToAdd = double.Parse(Console.ReadLine());
                    user.SetBalance(amountToAdd + user.GetBalance());

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"Your balance is {user.GetBalance()} $.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("User not found!");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
        }

        // Make a monthly payment of N dollars
        public void MakePayment(string username)
        {
            try
            {
                var user = users.FirstOrDefault(x => x.UserName == username);
                if (user != null)
                {
                    double currentBalance = user.GetBalance();
                    Console.Write("Enter the amount to pay: ");
                    double monthlyFee = double.Parse(Console.ReadLine());

                    if (currentBalance >= monthlyFee)
                    {
                        user.SetBalance(currentBalance - monthlyFee);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Payment of {monthlyFee} $ made successfully. Remaining balance is {user.GetBalance()} $.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Insufficient funds to make the payment. Please fill your balance.");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("User not found.");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
