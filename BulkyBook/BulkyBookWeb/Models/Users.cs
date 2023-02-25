using System;
using System.Collections.Generic;



namespace BulkyBookWeb.Models
{

    public partial class Users
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Contact { get; set; }
    }
}
