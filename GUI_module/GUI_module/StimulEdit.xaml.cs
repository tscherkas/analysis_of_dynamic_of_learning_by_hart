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

namespace GUI_module
{
    /// <summary>
    /// Interaction logic for Theory.xaml
    /// </summary>
    public partial class StimulEdit : Window
    {
        private bool previewMode = false;
        public StimulEdit()
        {
            InitializeComponent();
            PreviewButton.Click += PreviewButton_Click;
        }

        private void PreviewButton_Click(object sender, RoutedEventArgs e)
        {
            previewMode = !previewMode;
        }

        private void keywordsBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
