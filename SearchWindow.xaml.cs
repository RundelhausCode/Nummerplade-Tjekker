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
        public string vin;
        public SearchWindow()
        {
            InitializeComponent();
            vin = string.Empty;
    }

        private void Regbutton_Click(object sender, RoutedEventArgs e)
        { 
            vin = Regbox.Text;
            DialogResult = true;
        }

        private void Vinbutton_Click(object sender, RoutedEventArgs e)
        {
            
            vin = Vinbox.Text;
            DialogResult = true;
        }

        private void Regbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Regbox.Text.Length <= 7)
            {
                Regbutton.IsEnabled = true;
            }
            else
            {
                Regbutton.IsEnabled = false;
            }
        }

        private void Vinbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Vinbox.Text.Length == 17)
            {
                Vinbutton.IsEnabled = true;
            }
            else
            {
                Vinbutton.IsEnabled = false;
            }
            
        }
    }
}
