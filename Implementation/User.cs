using System.ComponentModel.DataAnnotations;

namespace Implementation
{
    public class User
    {
        private string _name;
        private string _surname;
        private string _phoneNumber;
        private string _email;
        private string _address;
        private string _password;

        public User()
        {

        }

        public User(string name, string surname, string phoneNumber, string email, string address, string password)
        {

            this._name = name;
            this._surname = surname;
            this._phoneNumber = phoneNumber;
            this._email = email;
            this._address = address;
            this._password = password;

            Name = _name;
            Surname = _surname;
            PhoneNumber = _phoneNumber;
            Email = _email;
            Address = _address;
            Password = _password;

        }
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }
        
        public string Address { get; set; }

        public string Password { get; set; }

        public override string ToString()
        {
            return Id + "\t" + Name + "\t" + Surname + "\t" + PhoneNumber + "\t" + Address + "\t" + Password;
        }
    }
}