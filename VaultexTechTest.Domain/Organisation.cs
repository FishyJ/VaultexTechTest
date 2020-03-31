using System;
using System.Collections.Generic;
using System.Text;

namespace VaultexTechTest.Domain
{
    public class Organisation
    {
        public Organisation()
        {
            Employees = new List<Employee>();
        }
        public Guid ID { get; set; }
        public string OrganisationName { get; set; }
        public string OrganisationNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public string Town { get; set; }
        public string Postcode { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
