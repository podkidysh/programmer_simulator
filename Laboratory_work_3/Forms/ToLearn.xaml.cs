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
using System.Windows.Shapes;

namespace Laboratory_work_3.Forms
{
    /// <summary>
    /// Логика взаимодействия для ToLearn.xaml
    /// </summary>
    public partial class ToLearn : Window
    {
        public ToLearn()
        {
            InitializeComponent();
        }

        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            GameWindow gameWindow = new GameWindow();
            gameWindow.Show();
            Close();
        }

        private void btReadArticles_Click(object sender, RoutedEventArgs e)
        {
            App.myGamer.Fatigue += 10;
            App.myWork.Experience += 10;
            MessageBox.Show("Вы успешно прочитали статьи");
            GameWindow gameWindow = new GameWindow();
            gameWindow.Show();
            Close();
        }

        private void btReadBooks_Click(object sender, RoutedEventArgs e)
        {
            if (App.myWork.Experience > 500)
            {
                if (App.myGamer.Money >= 200)
                {
                    App.myGamer.Fatigue += 20;
                    App.myWork.Experience += 20;
                    App.myGamer.Money -= 200;
                    MessageBox.Show("Вы успешно прочитали книги");
                    GameWindow gameWindow = new GameWindow();
                    gameWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Недостаточно денег");
                }
            }
            else
            {
                MessageBox.Show("Недостаточно опыта");
            }
        }

        private void btTakeCourses_Click(object sender, RoutedEventArgs e)
        {
            if (App.myWork.Experience > 1000)
            {
                if (App.myGamer.Money >= 500)
                {
                    App.myGamer.Fatigue += 30;
                    App.myWork.Experience += 30;
                    App.myGamer.Money -= 500;
                    MessageBox.Show("Вы успешно прошли курсы");
                    GameWindow gameWindow = new GameWindow();
                    gameWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Недостаточно денег");
                }
            }
            else
            {
                MessageBox.Show("Недостаточно опыта");
            }
        }
    }
}
