using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Services
{
    public class UpdateUserService
    {

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

        public UpdateUserService()
        {

        }

        public User ChangeUserData(User user)
        {
            string choice = GetUserInputOnChange();

            switch (choice.ToLower())
            {
                case "name":
                    Console.WriteLine("Enter new name: ");
                    string name = Console.ReadLine();
                    user.Name = name;
                    break;
                case "surname":
                    Console.WriteLine("Enter new surname: ");
                    string surname = Console.ReadLine();
                    user.Surname = surname;
                    break;
                case "phonenumber":
                    ChangeUserPhoneNumber(user);
                    break;
                case "email":
                    ChangeUserEmail(user);
                    break;
                case "address":
                    Console.WriteLine("Enter new address: ");
                    string address = Console.ReadLine();
                    user.Address = address;
                    break;
                case "password":
                    ChangeUserPassword(user);
                    break;
                default:
                    break;
            }
            return user;
        }
        private string GetUserInputOnChange()
        {
            Console.WriteLine("Enter what you want to change: (name,surname,password,email,phonenumber,address)");
            return Console.ReadLine();
        }
        private void ChangeUserPhoneNumber(User user)
        {
            Console.WriteLine("Enter new phone number: ");
            string number = Console.ReadLine();
            if (_phoneChecker.IsValid(number))
            {
                user.PhoneNumber = number;
            }
            else
            {
                Console.WriteLine("Bad phone number");
            }
        }

        private void ChangeUserEmail(User user)
        {
            Console.WriteLine("Enter new email: ");
            string email = Console.ReadLine();
            if (_emailChecker.IsValid(email))
            {
                user.Email = email;
            }
            else
            {
                Console.WriteLine("Incorrect email type");
            }
        }
        private void ChangeUserPassword(User user)
        {
            Console.WriteLine("Enter new password: ");
            string password = Console.ReadLine();
            if (_passwordChecker.IsValid(password))
            {
                user.Password = password;
            }
            else
            {
                Console.WriteLine("Incorrect password");
            }
        }

    }
}
