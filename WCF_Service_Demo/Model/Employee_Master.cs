using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace WcfServiceDemo.Model
{
    public class Employee_Master
    {
        public Employee_Master()
        {
        }
        public int Employee_Id { get; set; }

        public string Employee_Name { get; set; }

        public string Contact_No { get; set; }

        public string Email { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string zipCode { get; set; }
       
    }
}