using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VaultexTechTest.Data;
using VaultexTechTest.Domain;

namespace VaultexTechTest.ConsoleApp
{
    class Program
    {
        private static VaultexTechTestContext context = new VaultexTechTestContext(new DbContextOptions<VaultexTechTestContext>());

        static void Main(string[] args)
        {
            context.Database.EnsureCreated();
            var testOrg = new Organisation() {OrganisationName = "TheOrg"};
            context.Organisations.Add(testOrg);
            var testEmp = new Employee() {FirstName = "Bert", LastName = "Test", Organisation = testOrg};
            context.Employees.Add(testEmp);
            context.SaveChanges();
            var employees = context.Employees.ToList();
            var organisations = context.Organisations.ToString();
            Console.ReadLine();
        }
    }
}
