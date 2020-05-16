using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBQWebsite.Models
{
    public class Users
    {   
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public int ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public string MailingStreetAddress { get; set; }
        public string MailingCity { get; set; }
        public string MailingState { get; set; }
        public string MailingZip { get; set; }
        public string BillingStreetAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingZip { get; set; }
        public string Phone { get; set; }
        public Nullable<bool> Admin { get; set; }
        public Nullable<System.DateTime> SignupDate { get; set; }
        public Nullable<System.DateTime> LastLoginDate { get; set; }
    }
}
