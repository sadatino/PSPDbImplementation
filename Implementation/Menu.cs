using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation
{
    class Menu
    {

        private string mainText = "\nTYPE NUMBER TO PERFORM ACTION \n";
        private string options = "1. Create new user\n" +
                                 "2. Check all database\n" +
                                 "3. Update user\n" +
                                 "4. Delete user\n" +
                                 "0. Exit\n\n";

        CrudOperations _crudOperations = new CrudOperations();

        public Menu()
        {

        }

        public int GetUserChoice()
        {
            string choice;
            int numberChoice;

            choice = Console.ReadLine();
            numberChoice = Int32.Parse(choice);

            return numberChoice;
        }

        public void SwitchBetweenChoice()
        {
            int number = 1;
            while(number != 0)
            {
                Console.WriteLine(ToString());
                int choice = GetUserChoice();
                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        _crudOperations.Create();
                        break;
                    case 2:
                        _crudOperations.Read();
                        break;
                    case 3:
                        _crudOperations.Update();
                        break;
                    case 4:
                        _crudOperations.Delete();
                        break;
                    case 0:
                        number = 0;
                        break;
                    default:
                        break;
                }
            }  
        }

        public override string ToString()
        {
            return mainText + options;
        }

    }
}
