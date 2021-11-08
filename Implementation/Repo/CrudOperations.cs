using Implementation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation
{
    class CrudOperations
    {
        CreateUserService cus = new CreateUserService();
        ReadUsersService rus = new ReadUsersService();
        UpdateUserService uus = new UpdateUserService();

        public List<User> DatabaseUsers { get; private set; }

        public void Create()
        {
            User user = cus.CreateUser();

            using (DataContext context = new DataContext())
            {
                if(user != null)
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }      
            }

        }

        public void Read()
        {

            using (DataContext context = new DataContext())
            {
                DatabaseUsers = context.Users.ToList();
                rus.UserList = DatabaseUsers;

                rus.PrintList();

            }


        }

        public void Update()
        {
            Console.WriteLine("Enter id of user you want to update");
            string idString = Console.ReadLine();

            int id = Int32.Parse(idString);

            using (DataContext context = new DataContext())
            {
                DatabaseUsers = context.Users.ToList();
                rus.UserList = DatabaseUsers;

                User selectedUser = rus.UserList.Find(x => x.Id == id);

                if (selectedUser != null)
                {
                    User user = context.Users.Find(selectedUser.Id);
                    user = uus.ChangeUserData(user);
                    context.SaveChanges();

                }

            }

        }

        public void Delete()
        {

            Console.WriteLine("Enter id of user you want to delete");
            string idString = Console.ReadLine();

            int id = Int32.Parse(idString);

            using (DataContext context = new DataContext())
            {

                DatabaseUsers = context.Users.ToList();
                rus.UserList = DatabaseUsers;

                User selectedUser = rus.UserList.Find(x => x.Id == id);

                if (selectedUser != null)
                {
                    User user = context.Users.Find(selectedUser.Id);

                    context.Remove(user);
                    context.SaveChanges();

                }

            }

        }

    }
}
