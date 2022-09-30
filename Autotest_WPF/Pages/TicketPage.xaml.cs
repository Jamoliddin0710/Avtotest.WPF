using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Autotest_WPF
{
    /// <summary>
    /// Interaction logic for TicketPage.xaml
    /// </summary>
    public partial class TicketPage : Page
    {
        
        public TicketPage()
        {
            InitializeComponent();
            CreateButton();
        }
        
        public void CreateButton()
        {
            
            for (int i = 0; i < MainWindow.Instance.QuestionRepository.GetQuestionTicket(); i++)
            {
                var button = new Button();
                button.Style = FindResource("ButtonStyle") as Style;

                if (MainWindow.Instance.TicketRepository.TicketList.Any(t => t.Index == i))
                {
                    var ticket = MainWindow.Instance.TicketRepository.TicketList.First(t => t.Index == i);
                    button.Content = ticket.IsAllCorrect ? $"Ticket {i + 1}✔ " : $"Ticket {i + 1} {ticket.CorrectAnswerCount}/{ticket.Questionscount}";
                }
                else
                {
                    button.Content = $"Ticket {i + 1}";
                }

                button.Tag = i;
                button.Click += TicketChoiceClick;
                TicketPanel.Children.Add(button);
            }
           
        }

        private void TicketChoiceClick(object sender, RoutedEventArgs e)
        {
            var button = (sender as Button);
            var indexbutton = (int)button.Tag;
            MainWindow.Instance.MainFrame.Navigate(new ExaminationPage(indexbutton));
        }
    }
}
