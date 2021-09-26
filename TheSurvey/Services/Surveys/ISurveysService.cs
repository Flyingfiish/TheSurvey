using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSurvey.Db.Repository.Specifications;
using TheSurvey.Entities;

namespace TheSurvey.Services.Surveys
{
    public interface ISurveysService
    {
        public Task Create(Survey survey);

        public Task<List<SurveyDto>> Get(Specification<Survey> spec);

        public Task Update(Specification<Survey> spec, Action<Survey> func);

        public Task Delete(Specification<Survey> spec);
    }
}
