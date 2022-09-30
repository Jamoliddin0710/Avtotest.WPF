using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class TicketRepository
    {
        public int SolveTicket { get; set; }
        public int SolveQuestion { get; set; }
        public List<Ticket> TicketList { get; set; }
        public List<int> SelectedQuestionIndex { get; set; }

        private const string Folder = "UserData";
        private const string FileName = "usertickets.json";

        public void WriteAllText()
        {
            var TicketData = TicketList.
                Select(ticket => new Ticket(ticket.Index, ticket.Questionscount, ticket.CorrectAnswerCount));
           
            var jsonData = JsonConvert.SerializeObject(TicketData);
            if (!Directory.Exists(Folder))
            {
                Directory.CreateDirectory(Folder);
            }
            File.WriteAllText(Path.Combine(Folder, FileName), jsonData);
        }


        public TicketRepository()
        {
        //    SolveQuestion = TicketList.Sum(ticket => ticket.CorrectAnswerCount);
          // SolveTicket = TicketList.Count(ticket => ticket.IsAllCorrect);
            ReadUserJson();
            
        }
        public void ReadUserJson()
        {
               var jsonData = File.ReadAllText(Path.Combine(Folder, FileName));
 
                TicketList = JsonConvert.DeserializeObject<List<Ticket>>(jsonData);
              
        }
    
    }

}
