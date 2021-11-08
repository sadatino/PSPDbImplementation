using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Implementation
{
    class Program
    {
        static void Main(string[] args)
        {

            DatabaseFacade facade = new DatabaseFacade(new DataContext());
            facade.EnsureCreated();

            Menu menu = new Menu();
            menu.SwitchBetweenChoice();


        }
    }
}
