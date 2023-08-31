using Islamic_Stars_Pattern.Class;
using Islamic_Stars_Pattern.Interfaces;
using System;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using System.Windows.Shapes;

namespace Islamic_Stars_Pattern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int scale = 10;
        private int N; // N > 2
        private double a;
        private double b;
        private double G; // G = 1 , 2 , 3
        private double n;
        private int K; // K = 0 , 1 , 2

        FactoryInterface pattern;


        private void creator(String type)
        {
            if (type == "Rossete")
            {
                pattern = new Rossets(canvas ,N, G, K, a, b);
            }
            else if (type == "Stars")
            {

            }
        }

        public MainWindow()
        {

            /*InitializeComponent();

            DrawLine(setX(-(canvas.Width / 2)), setY(0), setX(canvas.Width / 2), setY(0), Brushes.Red);
            DrawLine(setX(0), setY(-(canvas.Height / 2)), setX(0), setY(canvas.Height / 2), Brushes.Red);
            primitivePattern();*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selctedType = (ComboBoxItem)type.SelectedItem;

            if (selctedType != null)
            {
                string type = selctedType.Content.ToString();
                if(type == "Rossete")
                {

                }
                else if(type == "Stars")
                {

                }
                MessageBox.Show($"Selected value: {type}");
            }
            else
            {
                MessageBox.Show("Please Select Type Of Pattern !");
            }
        }
    }
}
