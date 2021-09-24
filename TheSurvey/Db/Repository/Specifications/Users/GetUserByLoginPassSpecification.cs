using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSurvey.Entities;

namespace TheSurvey.Db.Repository.Specifications.Users
{
    public class GetUserByLoginPassSpecification : Specification<User>
    {
        public GetUserByLoginPassSpecification(string login, string passwrod)
        {
            Predicate = u => u.Login == login && u.HashPassword == passwrod;
        }
    }
}
