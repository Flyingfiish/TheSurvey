using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;

namespace TheSurvey.Entities

{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string HashPassword { get; set; }

        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string LastName { get; set; }
    }
}
