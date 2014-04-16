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
using System.Windows.Shapes;
using System.Drawing;

namespace CloudClassWPF
{
    /// <summary>
    /// Interaction logic for WhiteBoard.xaml
    /// </summary>
    public partial class WhiteBoard : Window
    {
        private bool isClicked = false;


        public WhiteBoard()
        {
            InitializeComponent();
            
        }

        private void ButtonPen_Click(object sender, RoutedEventArgs e)
        {
            if (!isClicked)
            {
                InkCanvas.IsEnabledProperty = true;
                ButtonPen.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                ButtonPen.BorderThickness = new Thickness(4);

                isClicked = true;
            }
            else
            {
                ButtonPen.BorderThickness = new Thickness(1);
                isClicked = false;
            }
        }

        private void ButtonEraser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonColors_Click(object sender, RoutedEventArgs e)
        {

        }

   }
}
