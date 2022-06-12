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
    /// Логика взаимодействия для GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        Model.Gamer Gamer;
        Model.Computer Computer;
        Model.Work Work;
        public GameWindow()
        {
            InitializeComponent();
            Gamer = App.myGamer;
            gridInfoGamer.DataContext = Gamer;

            Computer = App.myComputer;
            gridComputerInfo.DataContext = Computer;
            
            Work = App.myWork;
            gridInfoWork.DataContext = Work;
        }

        private void btNextDay_Click(object sender, RoutedEventArgs e)
        {
            if (Gamer.Satiety <= 0)
            {
                MainWindow mainWindow = new MainWindow();
                MessageBox.Show("Вы умерли от голода. Дней прожито: " + App.myGamer.Day);
                mainWindow.Show();
                Close();
            }
            if (Work.Name == "Практика дома")
            {
                Work.Experience += App.myWork.UpExperience;
                Gamer.Money += App.myWork.Wages;
                gridInfoWork.DataContext = null;
                gridInfoWork.DataContext = Work;
            }
            else if (Work.Name == "Оператор ЭВМ")
            {
                Work.Experience += App.myWork.UpExperience;
                Gamer.Money += App.myWork.Wages;
                gridInfoWork.DataContext = null;
                gridInfoWork.DataContext = Work;
            }
            else if (Work.Name == "Фриланс")
            {
                Work.Experience += App.myWork.UpExperience;
                Gamer.Money += App.myWork.Wages;
                gridInfoWork.DataContext = null;
                gridInfoWork.DataContext = Work;
            }
            else if (Work.Name == "Разработчик мобильных приложений")
            {
                Work.Experience += App.myWork.UpExperience;
                Gamer.Money += App.myWork.Wages;
                gridInfoWork.DataContext = null;
                gridInfoWork.DataContext = Work;
            }
            else if (Work.Name == "Разработчик компьютерных игр")
            {
                Work.Experience += App.myWork.UpExperience;
                Gamer.Money += App.myWork.Wages;
                gridInfoWork.DataContext = null;
                gridInfoWork.DataContext = Work;
            }
            else if (Work.Name == "Web-разработчик")
            {
                Work.Experience += App.myWork.UpExperience;
                Gamer.Money += App.myWork.Wages;
                gridInfoWork.DataContext = null;
                gridInfoWork.DataContext = Work;
            }
            else if (Work.Name == "Программист Яндекса")
            {
                Work.Experience += App.myWork.UpExperience;
                Gamer.Money += App.myWork.Wages;
                gridInfoWork.DataContext = null;
                gridInfoWork.DataContext = Work;
            }
            else if (Work.Name == "Программист Microsoft")
            {
                Work.Experience += App.myWork.UpExperience;
                Gamer.Money += App.myWork.Wages;
                gridInfoWork.DataContext = null;
                gridInfoWork.DataContext = Work;
            }
            else if (Work.Name == "Программист Google")
            {
                Work.Experience += App.myWork.UpExperience;
                Gamer.Money += App.myWork.Wages;
                gridInfoWork.DataContext = null;
                gridInfoWork.DataContext = Work;
            }
            else if (Work.Name == "Своя IT-компания")
            {
                Work.Experience += App.myWork.UpExperience;
                Gamer.Money += App.myWork.Wages;
                gridInfoWork.DataContext = null;
                gridInfoWork.DataContext = Work;
            }
            if (Gamer.Fatigue >= 100)
            {
                MessageBox.Show("Вы умерли от усталости. Дней прожито: " + Gamer.Day);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            if (Work.Experience >= 15000 && Work.Name == "Своя IT-компания" && Computer.Processor == 5 && Computer.VideoCard == 5 &&
                Computer.RamMemory == 5 && Computer.SSD == 5 && Computer.Cooling == 5 && Computer.Motherboard == 5 && Computer.PowerSupply == 5 && Computer.Body == 5)
            {
                MessageBox.Show("Поздравляем, вы прошли игру! Вам понадобилось на это " + Gamer.Day + " дней");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }

            Gamer.Fatigue = 0;
            Gamer.Day += 1;
            Gamer.Satiety -= 10;
            gridInfoGamer.DataContext = null;
            gridInfoGamer.DataContext = Gamer;
        }

        private void btWork_Click(object sender, RoutedEventArgs e)
        {
            WorkWindow workWindow = new WorkWindow();
            workWindow.ShowDialog();
            Close();
        }

        private void btCafe_Click(object sender, RoutedEventArgs e)
        {
            CafeWindow cafeWindow = new CafeWindow();
            cafeWindow.ShowDialog();
            Close();
            gridInfoGamer.DataContext = null;
            gridInfoGamer.DataContext = Gamer;
        }

        private void btSaveGame_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.Gamer newGamer = new Model.Gamer();
                Model.Computer newComputer = new Model.Computer();
                Model.Work newWork = new Model.Work();

                newGamer.Name = App.myGamer.Name;
                newGamer.Age = App.myGamer.Age;
                newGamer.Gender = App.myGamer.Gender;
                newGamer.Satiety = App.myGamer.Satiety;
                newGamer.Fatigue = App.myGamer.Fatigue;
                newGamer.Money = App.myGamer.Money;
                newGamer.Day = App.myGamer.Day;

                newComputer.Processor = App.myComputer.Processor;
                newComputer.VideoCard = App.myComputer.VideoCard;
                newComputer.RamMemory = App.myComputer.RamMemory;
                newComputer.SSD = App.myComputer.SSD;
                newComputer.Cooling = App.myComputer.Cooling;
                newComputer.Motherboard = App.myComputer.Motherboard;
                newComputer.PowerSupply = App.myComputer.PowerSupply;
                newComputer.Body = App.myComputer.Body;

                newWork.Name = App.myWork.Name;
                newWork.Wages = App.myWork.Wages;
                newWork.Minqualifications = App.myWork.Minqualifications;
                newWork.Experience = App.myWork.Experience;
                newWork.UpExperience = App.myWork.UpExperience;

                using DB.MySqlLiteContext mySqlLiteContext = new DB.MySqlLiteContext();
                mySqlLiteContext.Gamers.Add(newGamer);
                mySqlLiteContext.SaveChanges();
                mySqlLiteContext.Computers.Add(newComputer);
                mySqlLiteContext.SaveChanges();
                mySqlLiteContext.Works.Add(newWork);
                mySqlLiteContext.SaveChanges();

                MessageBox.Show("Вы сохранили игру");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btComputer_Click(object sender, RoutedEventArgs e)
        {
            ComputerWindow computerWindow = new ComputerWindow();
            computerWindow.ShowDialog();
            Close();
            gridComputerInfo.DataContext = null;
            gridComputerInfo.DataContext = Computer;
            gridInfoGamer.DataContext = null;
            gridInfoGamer.DataContext = Gamer;
            gridInfoWork.DataContext = null;
            gridInfoWork.DataContext = Work;
        }

        private void btLearning_Click(object sender, RoutedEventArgs e)
        {
            ToLearn toLearn = new ToLearn();
            toLearn.ShowDialog();
            Close();
            gridInfoGamer.DataContext = null;
            gridInfoGamer.DataContext = Gamer;
        }

        private void btexit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
