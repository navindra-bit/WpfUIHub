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

namespace LoginAndRegisterPage
{
    /// <summary>
    /// Interaction logic for Term_ConditionsPage.xaml
    /// </summary>
    public partial class Term_ConditionsPage : Window
    {
        public Term_ConditionsPage()
        {
            InitializeComponent();
        }

        private void TermAcceptbutton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TermRejectbutton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
