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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestVerktygWPF.Model;

namespace TestVerktygWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _Frame.Navigate(new View.AdminTestDetailManagementPage());
          
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //TODO: send UserName and Password to database and login if there is a match
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
                btnLogin_Click(sender, e);
        }
        private void AddData()
        {
            using (var db = new DbModel())
            {
                Student xStudent = new Student();
                xStudent.FirstName = "Hej";
                xStudent.LasttName = "Glensson";
                xStudent.Email = "Glenn";
                xStudent.UserName = "ASDGF";
                db.Students.Add(xStudent);
                db.SaveChanges();
            }
        }
    }
}
