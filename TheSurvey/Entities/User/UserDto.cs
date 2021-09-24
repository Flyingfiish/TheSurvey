using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheSurvey.Entities
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Login { get; set; }

        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string LastName { get; set; }
    }
}
