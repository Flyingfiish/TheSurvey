using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSurvey.Entities;

namespace TheSurvey.Db.Repository.Specifications.Users
{
    public class GetUserByIdSpecification : Specification<User>
    {
        public GetUserByIdSpecification(Guid id)
        {
            Predicate = u => u.Id == id;
        }
    }
}
