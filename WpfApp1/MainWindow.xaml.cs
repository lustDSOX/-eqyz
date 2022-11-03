using System;
using System.Collections;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool ok_answer = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Time.Text = "0";
            Random random = new Random();
            var blocks = plus_panel.Children.OfType<TextBlock>().ToList().
                Concat(minus_panel.Children.OfType<TextBlock>().ToList()).
                Concat(mult_panel.Children.OfType<TextBlock>().ToList()).
                Concat(divide_panel.Children.OfType<TextBlock>().ToList());

            foreach (TextBlock item in blocks)
            {
                item.Text = random.Next(1, 100).ToString();
            }
            Timer();
        }
        async void Timer()
        {
            Task task = Task.Delay(1000);
            while (!ok_answer)
            {
                Time.Text = (int.Parse(Time.Text) + 1).ToString();
                Thread.Sleep(500);
            }
        }
    }
}
