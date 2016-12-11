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

namespace GUI_module
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            EnterButton.Click += EnterApp;
        }

        private void EnterApp(object sender, RoutedEventArgs e)
        {
            Window w = new Window();
            w.Title = "Тест";
            if(expander.IsExpanded)
            {
                (new Results()).Show();
                (new Theory()).Show();
                (new Tests()).Show();
                w.Content = new TestEdit();
                w.Show();
                (new StimulEdit()).Show();
                (new StimulsCollections()).Show();
                (new AdminStartWindow()).Show();
            }
           
        }
    }
}