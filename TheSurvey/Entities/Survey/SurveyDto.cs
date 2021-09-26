using System;
using System.Collections.Generic;

namespace TheSurvey.Entities
{
    public class SurveyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsArchieve { get; set; }
        public List<QuestionDto> Questions { get; set; }
    }
}
