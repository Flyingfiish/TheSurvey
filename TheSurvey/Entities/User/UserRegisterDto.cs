using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheSurvey.Entities
{
    public class UserRegisterDto
    {
        public string Login { get; set; }
        public string HashPassword { get; set; }
    }
}
