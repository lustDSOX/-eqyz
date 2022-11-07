using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double plus_answer = 0;
        double minus_answer = 0;
        double mult_answer = 0;
        double divide_answer = 0;
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Time.Text = "30";
            Random random = new Random();
            var blocks = plus_panel.Children.OfType<TextBlock>().ToList().
                Concat(minus_panel.Children.OfType<TextBlock>().ToList()).
                Concat(mult_panel.Children.OfType<TextBlock>().ToList()).
                Concat(divide_panel.Children.OfType<TextBlock>().ToList());

            foreach (TextBlock item in blocks)
            {
                item.Text = random.Next(1, 5).ToString();
            }

            var block = minus_panel.Children.OfType<TextBlock>().ToList();
            minus_answer = double.Parse(block[0].Text) - double.Parse(block[1].Text);
            block = mult_panel.Children.OfType<TextBlock>().ToList();
            mult_answer = double.Parse(block[0].Text) * double.Parse(block[1].Text);
            block = divide_panel.Children.OfType<TextBlock>().ToList();
            divide_answer = Math.Round(double.Parse(block[0].Text) / double.Parse(block[1].Text),1);
            block = plus_panel.Children.OfType<TextBlock>().ToList();
            plus_answer = double.Parse(block[0].Text) + double.Parse(block[1].Text);

            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (answer_divide.Text == divide_answer.ToString() && answer_minus.Text == minus_answer.ToString() && answer_mult.Text == mult_answer.ToString() && answer_plus.Text == plus_answer.ToString())
            {
                timer.Stop();
                MessageBox.Show("ТЫ не ЛЕРУА МЕРЛЕН");
            }
            Time.Text = (double.Parse(Time.Text) - 1).ToString();
            if(Time.Text == "0")
            {
                MessageBox.Show("ТЫ ЛЕРУА МЕРЛЕН");
                timer.Stop();
            }
        }

    }
}
