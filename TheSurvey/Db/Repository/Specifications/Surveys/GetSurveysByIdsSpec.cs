using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSurvey.Entities;

namespace TheSurvey.Db.Repository.Specifications.Surveys
{
    public class GetSurveysByIdsSpec : Specification<Survey>
    {
        public GetSurveysByIdsSpec(List<Guid> ids)
        {
            Predicate = s => ids.Contains(s.Id);
            Includes = s => s.Include(s => s.Questions).ThenInclude(q => q.Variants);
        }
    }
}
