using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Services
{
    public class CreateUserService
    {
        private string _name;
        private string _surname;
        private string _phoneNumber;
        private string _email;
        private string _address;
        private string _password;

        PasswordChecker _passwordChecker = new PasswordChecker(6,
            new List<char>() {
                '&', '!', '#', '$', '%', '\'', '*', '+', '-', '/', '=', '?', '^', '_', '`', '{', '|', '}', '~', '.'
            });

        EmailValidator _emailChecker = new EmailValidator(new List<char>(){
                '£', '¢', '¡'
            }, 
            new List<char>(){
                '&', '!', '#', '$', '%', '\'', '*', '+', '-', '/', '=', '?', '^', '_', '`', '{', '|', '}', '~', '.'
            });

        PhoneValidator _phoneChecker = new PhoneValidator(8, "+370", "8");

        public List<User> DatabaseUsers { get; private set; }
        ReadUsersService rus = new ReadUsersService();

        public CreateUserService()
        {
            
        }
        
        private void ReadUserName()
        {
            Console.WriteLine("Enter name: ");
            _name = Console.ReadLine();
        }
        private void ReadUserSurname()
        {
            Console.WriteLine("Enter surname: ");
            _surname = Console.ReadLine();
        }
        private void ReadUserPhoneNumber()
        {
            Console.WriteLine("Enter phone number: ");
            _phoneNumber = Console.ReadLine();
        }
        private void ReadUserEmail()
        {
            Console.WriteLine("Enter email: ");
            _email = Console.ReadLine();
        }
        private void ReadUserAddress()
        {
            Console.WriteLine("Enter address: ");
            _address = Console.ReadLine();
        }
        private void ReadUserPassword()
        {
            Console.WriteLine("Enter password: ");
            _password = Console.ReadLine();
        }

        public void GetAllUserDataFromConsole()
        {
            ReadUserName();
            ReadUserSurname();
            ReadUserPhoneNumber();
            ReadUserEmail();
            ReadUserAddress();
            ReadUserPassword();
        }

        public User CreateUser()
        {
            User user;
            GetAllUserDataFromConsole();
            
            if(_passwordChecker.IsValid(_password) && _emailChecker.IsValid(_email) 
                && _phoneChecker.IsValid(_phoneNumber)) 
            {
                user = new User(_name, _surname, _phoneNumber, _email, _address, _password);
            }
            else
            {
                Console.WriteLine("Failed to create user");
                user = new User();
            }

            return user;
        }

    }
}
