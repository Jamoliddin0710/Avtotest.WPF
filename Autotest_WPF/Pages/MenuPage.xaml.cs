using Data;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
            QuestionResult.Text = $"{MainWindow.Instance.TicketRepository.SolveQuestion.ToString()}/{MainWindow.Instance.QuestionRepository.Questions.Count}";
            TicketResult.Text = $"{MainWindow.Instance.TicketRepository.SolveTicket.ToString()}/{MainWindow.Instance.QuestionRepository.GetQuestionTicket()}";
        }

        
        private void ExamButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.MainFrame.Navigate(new TicketPage());
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.MainFrame.Navigate(new ExaminationPage());
        }
    }
}
