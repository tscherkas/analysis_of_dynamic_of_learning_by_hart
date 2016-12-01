using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class Theory : Window
    {
        public Theory()
        {
            InitializeComponent();
            (this.FindName("PreviewButton") as Button).Click += RTF_EditorToReadModeSwitch;
            (this.FindName("SaveButton") as Button).Click += RTF_EditorToReadWriteModeSwitch;
            ImageInsertButton.Click += ImageInsert;
        }

        private void ImageInsert(object sender, RoutedEventArgs e)
        {
            Image i = new Image();
            Image.FromFile()
            if () {

            }
        }

        private File getImageFile()
        {
            throw new NotImplementedException();
        }

        private void RTF_EditorToReadWriteModeSwitch(object sender, RoutedEventArgs e)
        {
            RTF_Editor.IsReadOnly = false;
        }

        private void RTF_EditorToReadModeSwitch(object sender, RoutedEventArgs e)
        {
            RTF_Editor.IsReadOnly = true;
        }
    }
}
