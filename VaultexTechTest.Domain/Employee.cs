using System;

namespace VaultexTechTest.Domain
{
    public class Employee
    {
        public Guid ID { get; set; }
        public string OrganisationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Organisation Organisation { get; set; }
    }
}
