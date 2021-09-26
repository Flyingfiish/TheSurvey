using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSurvey.Entities;

namespace TheSurvey.Db.Repository.Specifications.Surveys
{
    public class GetSurveyIncludesAnswersSpec : Specification<Survey>
    {
        public GetSurveyIncludesAnswersSpec(Guid surveyId)
        {
            Predicate = s => s.Id == surveyId;
            Includes = s => s.Include(s => s.Questions).ThenInclude(q => q.Variants).ThenInclude(q => q.Answers);
        }
    }
}
