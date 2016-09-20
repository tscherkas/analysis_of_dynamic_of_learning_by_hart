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
            ImageInsertButton.Click += ImageInsert;
        }

        private void ImageInsert(object sender, RoutedEventArgs e)
        {
            BitmapImage bi = new BitmapImage(new Uri(getImageFile().FullName,UriKind.Absolute));
            Image image = new Image();
            image.Source = bi;
            InlineUIContainer container = new InlineUIContainer(image);
            Paragraph paragraph = new Paragraph(container);
            fld.Blocks.Add(paragraph);
        }

        private FileInfo getImageFile()
        {
            return new FileInfo("example.bmp");
        }
    }
}
