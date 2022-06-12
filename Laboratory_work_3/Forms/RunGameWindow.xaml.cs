﻿using System;
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
    /// Логика взаимодействия для RunGameWindow.xaml
    /// </summary>
    public partial class RunGameWindow : Window
    {
        public RunGameWindow()
        {
            InitializeComponent();

            Loaded += RunGameWindow_Loaded;
        }

        private void RunGameWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                DB.MySqlLiteContext mySqlLiteContext = new DB.MySqlLiteContext();
                var gamer = mySqlLiteContext.Gamers.ToList();
                var computer = mySqlLiteContext.Computers.ToList();
                var work = mySqlLiteContext.Works.ToList();
                dgListGame.ItemsSource = gamer;
                dgListComputer.ItemsSource = computer;
                dgListWork.ItemsSource = work;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btRunGame_Click(object sender, RoutedEventArgs e)
        {
            App.myGamer = dgListGame.SelectedItem as Model.Gamer;
            App.myComputer = dgListComputer.SelectedItem as Model.Computer;
            App.myWork = dgListWork.SelectedItem as Model.Work;

            if (App.myGamer.GamerId == App.myComputer.ComputerId)
            {
                if (App.myGamer.GamerId == App.myWork.WorkId)
                {
                    GameWindow gameWindow = new GameWindow();
                    gameWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Выберете поля с одинаковым id");
                }
            }
            else
            {
                MessageBox.Show("Выберете поля с одинаковым id");
            }
            
        }
    }
}
