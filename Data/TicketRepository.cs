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
        public TicketRepository()
        {
            TicketList = new List<Ticket>();
            SolveTicket = 0;
            SolveQuestion = 0;
        }
    }
}
