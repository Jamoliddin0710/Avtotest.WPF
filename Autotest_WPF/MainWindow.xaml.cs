using Data;
using System.Windows;

namespace Autotest_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MainWindow();
                return _instance;
            }
        }

        private static MainWindow _instance;
        public QuestionRepository QuestionRepository;
        public TicketRepository TicketRepository;
        public MainWindow()
        {

            InitializeComponent();
            _instance = this;
              QuestionRepository = new QuestionRepository();
            TicketRepository = new TicketRepository();
         MainWindow.Instance.MainFrame.Navigate(new MenuPage());
         
        }
        public void DisplayPage(EPage page)
        {
            switch (page)
            {
                case EPage.Examination: MainWindow.Instance.MainFrame.Navigate(new ExaminationPage()); break;
                case EPage.Ticket: MainWindow.Instance.MainFrame.Navigate(new TicketPage()); break;
                default: MainWindow.Instance.MainFrame.Navigate(new MenuPage()); break;
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow.Instance.TicketRepository.WriteAllText();
        }
    }
}
