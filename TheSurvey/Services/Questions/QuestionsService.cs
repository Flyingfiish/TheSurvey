using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSurvey.Db.Repository;
using TheSurvey.Db.Repository.Specifications;
using TheSurvey.Entities;

namespace TheSurvey.Services.Questions
{
    public class QuestionsService : IQuestionsService
    {
        private readonly IRepository<Question> _questionsRepository;

        public QuestionsService(IRepository<Question> questionsRepository)
        {
            _questionsRepository = questionsRepository;
        }

        public async Task Create(Question question)
        {
            await _questionsRepository.Create(question);
        }

        public async Task Delete(Specification<Question> spec)
        {
            await _questionsRepository.Delete(spec);
        }

        public async Task<List<Question>> Get(Specification<Question> spec)
        {
            return await _questionsRepository.ReadMany(spec);
        }

        public async Task Update(Specification<Question> spec, Action<Question> func)
        {
            await _questionsRepository.Update(spec, func);
        }
    }
}
