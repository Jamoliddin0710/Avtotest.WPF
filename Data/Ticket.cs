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
        public List<IndexSave> IndexSaves { get; set; }
        public bool IsAllCorrect
        {
            get
            {
                return CorrectAnswerCount == Questionscount;
            }
        }
        public bool IsChoiceComplited(int questionindex , int choiceindex)
        {
            return IndexSaves.Any(qu => qu.QuestionIndex == questionindex && qu.ChoiceIndex == choiceindex);
        } 
        public bool IsComplited(int questionindex)
        {
          return IndexSaves.Any(qu => qu.QuestionIndex == questionindex);
        }
        public Ticket(int index,  List<QuestionEntity> questions)
        {
            Index = index;
            Questionscount = questions.Count;
            Questions = questions;
            CorrectAnswerCount = 0;
            IndexSaves = new List<IndexSave>();
        }
        
        public Ticket(int index , int correctanswer , int questioncount)
        {
            Index=index;
            Questionscount = correctanswer;
            CorrectAnswerCount = questioncount;
        }
        public Ticket()
        {

        }
    }
    public class IndexSave
    {
        public int QuestionIndex { get; set; }
        public int ChoiceIndex { get; set; }
        public bool  isCorrectAnswer { get; set; }
        public IndexSave(int questionIndex, int choiceIndex, bool correcatAnswer)
        {
            QuestionIndex = questionIndex;
            ChoiceIndex = choiceIndex;
            isCorrectAnswer = correcatAnswer;
        }
        public IndexSave(  int questionIndex, int choiceIndex)
        {
            
            QuestionIndex = questionIndex;
            ChoiceIndex = choiceIndex;
        }
    }
}
