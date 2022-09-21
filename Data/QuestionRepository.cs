using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autotest_WPF;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Data
{
    public class QuestionRepository
    {
        public List<QuestionEntity> Questions;
        public int QuestionsCount;
        //public List<Ticket> UserTicket = new List<Ticket>();
        public QuestionRepository()
        {
             ReadQuestionJson();
           
        }
        public void ReadQuestionJson()
        {
            var jsonPath = File.ReadAllText("C:\\Users\\User\\source\\repos\\Autotest_WPF\\Autotest_WPF\\JsonData\\uzlotin.json");
             Questions = JsonConvert.DeserializeObject<List<QuestionEntity>>(jsonPath);

        }

        public int GetQuestionTicket()
        {
            return Questions.Count / QuestionCounForSettings.TicketQuestionCount;
        }

        public List<QuestionEntity> CreateForTicket(int from , int count)
        {
            return  Questions.Skip(from).Take(count).ToList();
        }
        

    }
}
