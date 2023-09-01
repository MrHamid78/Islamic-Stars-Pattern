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
        
        string patternType;

        int scale = 1;
        private int N; // N > 2
        private double G; // G = 1 , 2 , 3
        private int K; // K = 0 , 1 , 2

        private double a;
        private double b;
        private double n;
        public MainWindow()
        {
        }

        private void creator()
        {
            canvas.Children.Clear();

            Draw.DrawXAndYAxis(canvas);

            if (this.patternType == "Rossete")
            {
                pattern = new Rossets(canvas ,N, G, K, a, b);
            }
            else if (this.patternType == "Stars")
            {
                pattern = new Stars(canvas, N, K, a, b);
            }

            if(pattern != null)
            {
                pattern.draw();
            }
        }

        private bool checkInputs()
        {
            if (NInput.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill N", "Error");
                return false;
            }
            else if (GInput.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill G", "Error");
                return false;
            }
            else if (KInput.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill K", "Error");
                return false;
            }

            else if (aInput.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill B(x)", "Error");
                return false;
            }

            else if (bInput.Text.Trim() == "")
            {
                MessageBox.Show("Please Fill B(y)", "Error");
                return false;
            }

            else
            {
                return true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selctedType = (ComboBoxItem)type.SelectedItem;

            if (selctedType != null)
            {
                string patternType = selctedType.Content.ToString();
                if(patternType != "Rossete" && patternType != "Stars")
                {
                    MessageBox.Show("Invalid Type Selection !");

                }
                else if(checkInputs())
                {
                    this.N = Int32.Parse(NInput.Text);
                    this.K = Int32.Parse(KInput.Text);
                    this.G = Double.Parse(GInput.Text);
                    this.a = Double.Parse(aInput.Text);
                    this.b = Double.Parse(bInput.Text);
                    this.patternType = patternType;
                    creator();

                }
            }
            else
            {
                MessageBox.Show("Please Select Type Of Pattern !" , "Error");
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.creator();
        }

        private void type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selctedType = (ComboBoxItem)type.SelectedItem;

            if (selctedType != null)
            {
                string patternType = selctedType.Content.ToString();
                if (patternType == "Stars")
                {
                    GInput.IsReadOnly = true;
                    GInput.Background = Brushes.LightGray;
                    GInput.Text = "0";
                    bInput.IsReadOnly = true;
                    bInput.Background = Brushes.LightGray;
                    bInput.Text = "0";
                }
                else
                {
                    GInput.IsReadOnly = false;
                    GInput.Background = SystemColors.ControlBrush;
                    GInput.Text = "";
                    bInput.IsReadOnly = false;
                    bInput.Background = SystemColors.ControlBrush;
                    bInput.Text = "";
                }
            }
        }

        private void zoomSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double zoom = zoomSlider.Value;
            ScaleLabel.Content = "Scale : " + zoom;
            this.scale = Int32.Parse(zoom);
            this.creator();
        }
    }
}
