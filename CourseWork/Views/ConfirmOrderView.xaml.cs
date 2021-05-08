﻿using CourseWork.Properties;
using CourseWork.Services;
using CourseWork.ViewModels;
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

namespace CourseWork.Views
{
    /// <summary>
    /// Логика взаимодействия для ConfirmOrderView.xaml
    /// </summary>
    public partial class ConfirmOrderView : UserControl
    {
        ConfirmOrderViewModel a = new ConfirmOrderViewModel();
        public ConfirmOrderView()
        {
            InitializeComponent();
            DataContext = a;
            Random rand = new Random();
            int code = rand.Next(99999);
            EmailSenderService.SendCode(Settings.Default.UserMail, code).GetAwaiter();
            a.code = code;
        }
    }
}
