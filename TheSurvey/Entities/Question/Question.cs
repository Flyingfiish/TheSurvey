using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheSurvey.Entities
{
    public class Question
    {
        public Guid Id { get; set; }
        public Guid SurveyId { get; set; }
        public Survey Survey { get; set; }
        public string Text { get; set; }
        public List<Variant> Variants { get; set; }
        public QuestionType QuestionType { get; set; }
    }

    public enum QuestionType
    {
        Single,
        Multiple,
        Input
    }
}
