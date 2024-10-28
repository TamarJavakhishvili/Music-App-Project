using Music_App_Project.Registration;
using Music_App_Project;
using System.Data;
using System.Text.RegularExpressions;

class Program
{
    static void Main() 
    {
        
        MusicAppMenu.RegisterAndLogin();
        MusicAppMenu.ManageMusic();

        

        Console.ReadKey();
    }

}