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

namespace GUI_module.Views
{
    /// <summary>
    /// Interaction logic for StimulCollectionEdit.xaml
    /// </summary>
    public partial class TestEdit : Page
    {
        public TestEdit()
        {
            InitializeComponent();
            comboBox.Items.Add("Слова 1");
            comboBox.Items.Add("Цифры 2");
            comboBox.Items.Add("Картинки 3");
        }
    }
}
