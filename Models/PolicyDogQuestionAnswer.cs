using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBQWebsite.Models
{
    public class PolicyDogQuestionAnswer
    {
        public int Id { get; set; }
        public Nullable<int> PolicyId { get; set; }
        public Nullable<int> PolicyDogId { get; set; }
        public Nullable<int> QuestionID { get; set; }
        public Nullable<int> AnswerID { get; set; }
        public string AnswerText { get; set; }
    }
}
