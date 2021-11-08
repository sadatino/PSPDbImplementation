using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Services
{
    public class ReadUsersService
    {
        List<User> userList = new List<User>();

        public List<User> UserList { get; set; }

        public ReadUsersService()
        {
            UserList = userList;
        }

        public void PrintList()
        {
            foreach(var ls in UserList)
            {
                Console.WriteLine(ls.ToString());
            }
        }

    }
}
