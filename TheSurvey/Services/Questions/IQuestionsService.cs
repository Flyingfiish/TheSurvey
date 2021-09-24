using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSurvey.Db.Repository.Specifications;
using TheSurvey.Entities;

namespace TheSurvey.Services.Questions
{
    public interface IQuestionsService
    {
        public Task Create(Question question);

        public Task<List<Question>> Get(Specification<Question> spec);

        public Task Update(Specification<Question> spec, Action<Question> func);

        public Task Delete(Specification<Question> spec);
    }
}
