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

        FactoryInterface pattern;

        int scale = 10;
        private int N; // N > 2
        private double G; // G = 1 , 2 , 3
        private int K; // K = 0 , 1 , 2

        private double a;
        private double b;
        private double n;

        private void creator(String type)
        {
            if (type == "Rossete")
            {
                pattern = new Rossets(canvas ,N, G, K, a, b);
                pattern.drawPrimitivePattern();
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
                if(type != "Rossete" && type != "Stars")
                {
                    MessageBox.Show("Invalid Type Selection !");

                }
                else
                {
                    this.N = Int32.Parse(NInput.Text);
                    this.K = Int32.Parse(KInput.Text);
                    this.G = Double.Parse(GInput.Text);
                    this.a = Double.Parse(aInput.Text);
                    this.b = Double.Parse(bInput.Text);
                    creator(type);
                }
            }
            else
            {
                MessageBox.Show("Please Select Type Of Pattern !");
            }
        }
    }
}
