using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Ticket
    {
        public int Index { get; set; }
        public int Questionscount { get; set; }
        public List<QuestionEntity> Questions { get; set; }
        public int CorrectAnswerCount { get; set; }
        public bool IsComplited
        {
            get
            {
                return CorrectAnswerCount == Questionscount;
            }
        }
        public Ticket(int index,  List<QuestionEntity> questions)
        {
            Index = index;
            Questionscount = questions.Count;
            Questions = questions;
            CorrectAnswerCount = 0;
        }
    }
}
