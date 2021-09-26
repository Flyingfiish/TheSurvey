using System;
using System.Threading.Tasks;
using TheSurvey.Db.Repository.Specifications;
using TheSurvey.Entities;
using TheSurvey.Services.Questions;
using TheSurvey.Services.Surveys;
using TheSurvey.Services.Users;
using TheSurvey.Services.Variants;

namespace TheSurvey.Services
{
    public class TestSurveyService
    {
        private readonly UsersService _usersService;

        private readonly ISurveysService _surveysService;
        private readonly IQuestionsService _questionsService;
        private readonly IVariantsService _variantsService;

        public TestSurveyService(UsersService usersService, ISurveysService surveysService, IQuestionsService questionsService, IVariantsService variantsService)
        {
            _usersService = usersService;

            _surveysService = surveysService;
            _questionsService = questionsService;
            _variantsService = variantsService;
        }
        
        public async Task Create()
        {
            await _usersService.Register(new UserRegisterDto()
            {
                Login = "123",
                HashPassword = "123"
            });

            var user = await _usersService.GetUser(new Specification<User>()
            {
                Predicate = u => u.Login == "123"
            });

            var rnd = new Random();

            var survey = new Survey()
            {
                Name = $"Это тестовый опрос {rnd.Next()}",
                UserId = user.Id
            };

            await _surveysService.Create(survey);

            var question = new Question()
            {
                Text = "Тестовый вопрос?",
                SurveyId = survey.Id,
                QuestionType = QuestionType.Single
            };

            await _questionsService.Create(question);

            var variant1 = new Variant()
            {
                Text = "Да",
                QuestionId = question.Id
            };

            var variant2 = new Variant()
            {
                Text = "Нет",
                QuestionId = question.Id
            };

            await _variantsService.Create(variant1);
            await _variantsService.Create(variant2);
        }
    }
}
