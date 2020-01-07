using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Nummerplade_Tjekker
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        public string reg = string.Empty;
        public string vin = string.Empty;
        public SearchWindow()
        {
            InitializeComponent();
        }

        private void Regbutton_Click(object sender, RoutedEventArgs e)
        {
            RegControl();
            DialogResult = true;
        }

        private void Vinbutton_Click(object sender, RoutedEventArgs e)
        {
            VinControl();
            DialogResult = true;
        }
        private bool RegControl()
        {
            reg = Regbox.Text;
            return true;
        }
        private bool VinControl()
        {
            vin = Vinbox.Text;
            return true;
        }


    }
}
