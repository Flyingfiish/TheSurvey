using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSurvey.Db.Repository;
using TheSurvey.Db.Repository.Specifications;
using TheSurvey.Entities;

namespace TheSurvey.Services.Answers
{
    public class AnswersService : IAnswersService
    {
        private readonly IRepository<Answer> _answersRepository;

        public AnswersService(IRepository<Answer> answersRepository)
        {
            _answersRepository = answersRepository;
        }

        public async Task Create(Answer answer)
        {
            await _answersRepository.Create(answer);
        }

        public Task Delete(Specification<Answer> spec)
        {
            throw new NotImplementedException();
        }

        public Task<List<Answer>> Get(Specification<Answer> spec)
        {
            throw new NotImplementedException();
        }

        public Task Update(Specification<Answer> spec, Action<Answer> func)
        {
            throw new NotImplementedException();
        }
    }
}
