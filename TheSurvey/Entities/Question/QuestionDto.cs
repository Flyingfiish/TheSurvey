using System;
using System.Collections.Generic;

namespace TheSurvey.Entities
{
    public class QuestionDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public List<VariantDto> Variants { get; set; }
        public QuestionType QuestionType { get; set; }
    }
}
