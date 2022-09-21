using Autotest_WPF.Pages;
using Data;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Autotest_WPF;
/// <summary>
/// Interaction logic for ExaminationPage.xaml
/// </summary>

public partial class ExaminationPage : Page
{
    private Ticket CurrentTicket;


    public int currentindex;
    public bool isTicket;
    public ExaminationPage(int? indexbutton = null)
    {
        InitializeComponent();

        if (indexbutton != null)
        {
            CurrentTicket = CreateForExamQuestions(indexbutton.Value);
            Ticket.Content = $"Ticket {indexbutton.Value + 1}";
            isTicket = true;

        }
        else
        {
            var randomTicketIndex = new Random().Next(MainWindow.Instance.QuestionRepository.Questions.Count / QuestionCounForSettings.TicketQuestionCount);
            Ticket.Content = $"ExaminationStart ({randomTicketIndex + 1})";
            CurrentTicket = CreateForExamQuestions(randomTicketIndex);
        }
        currentindex = 0;

        ShowQuestions();

    }
    QuestionEntity question;
    public void ShowQuestions()
    {


        ShowQuestionIndexButton();
        question = CurrentTicket.Questions[currentindex];
        ChangeButton(true);
        LoadQuestionImage(question.Media);
        SavolText.Text = question.Question;
        CreateChoiceButton();
    }

    public void ChangeButton(bool IsChange)
    {
        var button = QuestionIndexButton.Children[currentindex] as Button;
        if (IsChange)
        {
            button.Width = 40;
            button.Height = 40;
            button.FontWeight = FontWeights.Bold;
            button.FontSize = 18;
        }
        else
        {
            button.Width = 30;
            button.Height = 30;
            button.FontWeight = FontWeights.Light;
            button.FontSize = 14;
        }
    }
    public void ShowQuestionIndexButton()
    {
        QuestionIndexButton.Children.Clear();
        CHoicePanel.Children.Clear();

        for (int i = 0; i < CurrentTicket.Questions.Count; i++)
        {
            //ChangeButton(false);
            var question = CurrentTicket.Questions[i];
            var button = new Button();
            if (question.Isclicked)
            {
                if (question.IsCorrect)
                {
                    button.Background = new SolidColorBrush(Colors.Green);
                }
                else
                {
                    button.Background = new SolidColorBrush(Colors.Red);
                }
            }

            button.Tag = i;
            button.Content = i + 1;
            button.Width = 30;
            button.Height = 30;
            button.Click += ChoiceQuestionIndex;
            button.FontSize = 14;
            QuestionIndexButton.Children.Add(button);
        }

    }

    private void ChoiceQuestionIndex(object sender, RoutedEventArgs e)
    {
        ChangeButton(false);
        var questionindex = ((sender as Button).Tag);

        currentindex = Convert.ToInt32(questionindex);

        ShowQuestions();
    }

    public void CreateChoiceButton()
    {
        var choice = CurrentTicket.Questions[currentindex].Choices;
        for (int i = 0; i < choice.Count; i++)
        {
            var button = new Button();
            button.Style = FindResource("ChoiceButton") as Style;
            if (choice[i].IsSelected)
            {
                if (choice[i].Answer)
                {
                    button.Background = new SolidColorBrush(Colors.Green);
                    (QuestionIndexButton.Children[currentindex] as Button).Background = Brushes.Green;
                }
                else
                {
                    button.Background = new SolidColorBrush(Colors.Red);
                    (QuestionIndexButton.Children[currentindex] as Button).Background = Brushes.Red;
                }
            }


            button.Tag = i;
            var Textblock = new TextBlock();
            Textblock.Text = $"{choice[i].Text}";
            Textblock.TextWrapping = TextWrapping.Wrap;
            button.Content = Textblock;

            button.DataContext = question.Choices[i];
            button.Click += ChoiceButton_Click;

            CHoicePanel.Children.Add(button);
        }
    }

    private void ChoiceButton_Click(object sender, RoutedEventArgs e)
    {
        if (CurrentTicket.Questions[currentindex].Isclicked == true) return;
        var button = sender as Button;
        var choice = (Choice)button.DataContext;

        if (choice.Answer)
        {
            button.Background = new SolidColorBrush(Colors.Green);
            (QuestionIndexButton.Children[currentindex] as Button).Background = Brushes.Green;
            CurrentTicket.CorrectAnswerCount++;
            CurrentTicket.Questions[currentindex].IsCorrect = true;


        }
        else
        {
            button.Background = new SolidColorBrush(Colors.Red);
            (QuestionIndexButton.Children[currentindex] as Button).Background = Brushes.Red;

        }

        choice.IsSelected = true;

        CurrentTicket.Questions[currentindex].Isclicked = true;
    }

     

    private void Back_Click(object sender, RoutedEventArgs e)
    {
        MainWindow.Instance.MainFrame.Navigate(new MenuPage());
    }

    public void LoadQuestionImage(Media questionmedia)
    {
        string imagePath;
        if (questionmedia.Exist)
            imagePath = Path.Combine(Environment.CurrentDirectory, "QuestionImages", $"{questionmedia.Name}.png");
        else imagePath = Path.Combine(Environment.CurrentDirectory, "QuestionImages", $"car.png");
        QuestionImage.Source = new BitmapImage(new Uri(imagePath));
    }
    
    public Ticket CreateForExamQuestions(int ticketIndex)
    {
        var QuestionList = MainWindow.Instance.QuestionRepository.Questions.Skip(ticketIndex * QuestionCounForSettings.TicketQuestionCount).Take(QuestionCounForSettings.TicketQuestionCount).ToList();
        return new Ticket(ticketIndex, QuestionList);
    }

    private void Result_Click(object sender, RoutedEventArgs e)
    {
        if (isTicket)
        {
            MainWindow.Instance.MainFrame.Navigate(new ExamResultPage(CurrentTicket));
            MainWindow.Instance.TicketRepository.TicketList.Add(CurrentTicket);
            MainWindow.Instance.TicketRepository.SolveTicket++;
            MainWindow.Instance.TicketRepository.SolveQuestion += CurrentTicket.CorrectAnswerCount;
        }
        else
        {
            MainWindow.Instance.MainFrame.Navigate(new ExamResultPage(CurrentTicket));
        }
    }
    
}



