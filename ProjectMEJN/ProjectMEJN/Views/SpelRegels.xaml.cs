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

namespace ProjectMEJN.Views
{
    /// <summary>
    /// Interaction logic for SpelRegels.xaml
    /// </summary>
    public partial class SpelRegels : Window
    {
        public SpelRegels()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HomeScreen home = new HomeScreen();
            home.Show();
            this.Close();
        }
    }
}