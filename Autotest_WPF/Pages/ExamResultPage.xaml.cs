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

namespace Autotest_WPF.Pages
{
    /// <summary>
    /// Interaction logic for ExamResultPage.xaml
    /// </summary>
    public partial class ExamResultPage : Page
    {
        public ExamResultPage(Ticket Ticket)
        {
            InitializeComponent();
            QuestionCount.Text = Ticket.Questionscount.ToString();
            CorrectAnswerCount.Text = Ticket.CorrectAnswerCount.ToString();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.MainFrame.Navigate(new MenuPage());
        }
    }
}
