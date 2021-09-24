using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSurvey.Db.Repository.Specifications;
using TheSurvey.Entities;

namespace TheSurvey.Services.Answers
{
    public interface IAnswersService
    {
        public Task Create(Answer survey);

        public Task<List<Answer>> Get(Specification<Answer> spec);

        public Task Update(Specification<Answer> spec, Action<Answer> func);

        public Task Delete(Specification<Answer> spec);
    }
}
