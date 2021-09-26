using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSurvey.Entities;

namespace TheSurvey.Db.Repository.Specifications.Questions
{
    public class GetQuestionByIdIncludeAnswerSpec : Specification<Question>
    {
        public GetQuestionByIdIncludeAnswerSpec(Guid questionId)
        {
            Predicate = q => q.Id == questionId;
            Includes = (q) => q.Include(q => q.Variants);
        }
    }
}
