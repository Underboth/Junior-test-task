using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Test_task.Models;
using Test_task.Models.InputTableWindowModels;

namespace Test_task
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class InputWindow : Window
    {
        
        public InputWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            SelectPath RKK = new SelectPath();
            Data.RKK_File_Path = RKK.Path;
            TextBox1.Text = RKK.FileName;
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
           SelectPath Appeals = new SelectPath();
            Data.Appeal_File_Path = Appeals.Path;
            TextBox2.Text = Appeals.FileName;
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Data.sWatch.Start();
            CreateTable Table = new CreateTable();
            this.Hide();
        }
    }
}
