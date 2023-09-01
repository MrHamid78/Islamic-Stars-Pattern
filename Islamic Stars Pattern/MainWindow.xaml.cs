using Islamic_Stars_Pattern.Class;
using Islamic_Stars_Pattern.Interfaces;
using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
            if(canvas != null) { 
                canvas.Children.Clear();

                Draw.DrawXAndYAxis(canvas);

                if (this.patternType == "Rossete")
                {
                    pattern = new Rossets(canvas ,N, G, K, a, b , this.scale);
                }
                else if (this.patternType == "Stars")
                {
                    pattern = new Stars(canvas, N, K, a, b, this.scale);
                }

                if(pattern != null)
                {
                    pattern.draw();
                }
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
            this.scale = (int) zoom;
            ScaleLabel.Content = "Scale : " + zoom;
            this.creator();
        }


        private bool IsValidDouble(string text)
        {
            // Try to parse the text as a double
            if (double.TryParse(text, out double result))
            {
                // Successfully parsed as a double
                return true;
            }

            // Check if the text contains a single decimal point
            if (text.Count(c => c == '.') == 1)
            {
                return double.TryParse(text, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out result);
            }

            // Invalid double
            return false;
        }
        private bool IsNegativeDouble(string text)
        {
            if (text == "-")
            {
                return true; // Allow a single negative sign
            }

            if (text.StartsWith("-"))
            {
                text = text.Substring(1); // Remove the negative sign
            }

            return IsValidDouble(text); // Check if the remaining text is a valid double
        }
        private void DoubleTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Check if the entered text is a valid double
            TextBox textBox = sender as TextBox;
            string newText = textBox.Text.Insert(textBox.CaretIndex, e.Text);

            if (!IsValidDouble(newText) && !IsNegativeDouble(newText) && !e.Text.All(char.IsControl))
            {
                e.Handled = true; // Prevent the invalid input from being entered
            }
        }

        
    }
}
