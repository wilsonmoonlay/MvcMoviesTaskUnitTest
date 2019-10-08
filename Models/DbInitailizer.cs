using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcMovie.Models;

namespace MvcMovie.Models
{
    public static class DbInitailizer
    {
        public static void Initialize(AdventureWorksLT2012Context context)
        {
            context.Database.EnsureCreated();

            if (context.Customer.Any())
            {
                return;
            }

            var Customer = new Customer[]
            {
                new Customer{Title="Mr.",FirstName="John", LastName="Doe", ModifiedDate=DateTime.Parse("2019-05-19")},
                new Customer{Title="Ms.",FirstName="Mary", LastName="Riana", ModifiedDate=DateTime.Parse("2019-06-20")},
            };
            foreach (Customer c in Customer){
                context.Customer.Add(c);
            }
            context.SaveChanges();

            Console.WriteLine("Data has been saved!!");
        }
    }
}
