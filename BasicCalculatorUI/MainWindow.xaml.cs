using System.Windows;
using System.Windows.Controls;

namespace SimpleCalculatorWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Constructor: Initializes the components (UI elements)
        public MainWindow()
        {
            InitializeComponent();
        }
        // Fields to store the two numbers and the selected operator
        string firstnum = "";
        string secondnum = "";
        string opert = "";


        /// <summary>
        /// Handles number button clicks.
        /// Appends the number to either firstnum or secondnum depending on whether an operator has been selected.
        /// </summary>
        private void number_Click(object sender, RoutedEventArgs e)
        {
            Button num = (Button)sender;
            if (opert == "")
            {
                // Appending to the first number
                firstnum = firstnum + num.Content.ToString();
                result.Text = firstnum;
            }
            else
            {
                // Appending to the second number
                secondnum = secondnum + num.Content.ToString();
                result.Text = secondnum;
            }
            // Display the current expression (e.g., 12 + 3)
            result.Text = firstnum + " " + opert + " " + secondnum;
        }
        /// <summary>
        /// Handles operator button clicks (+, -, *, /).
        /// Stores the selected operator and displays it.
        /// </summary>
        private void oper_Click(object sender, RoutedEventArgs e)
        {
            Button oper = (Button)sender;

            opert = oper.Content.ToString() ?? string.Empty;
            result.Text = firstnum + " " + opert;

        }
        /// <summary>
        /// Clears all stored input and the result display.
        /// </summary>
        private void clear_Click(object sender, RoutedEventArgs e)
        {


            firstnum = "";
            secondnum = "";
            opert = "";
            result.Clear();
        }
        /// <summary>
        /// Handles the equal (=) button click.
        /// Performs the selected arithmetic operation and displays the result.
        /// </summary>
        private void equal_Click(object sender, RoutedEventArgs e)
        {

            // If only one number is entered, return it
            if (firstnum.Equals(""))
            {
                result.Text = secondnum;
                return;
            }
            else if (secondnum.Equals(""))
            {
                result.Text = firstnum;
                return;
            }
            // Convert the input strings to integers
            int num1 = Convert.ToInt16(firstnum);
            int num2 = Convert.ToInt16(secondnum);

            // Perform the operation based on the selected operator
            switch (opert)
            {
                case "+":
                    {
                        result.Text = (num1 + num2).ToString();
                        break;
                    }
                case "-":
                    {
                        result.Text = (num1 - num2).ToString();
                        break;
                    }
                case "*":
                    {
                        result.Text = (num1 * num2).ToString();
                        break;
                    }
                case "/":
                    {
                        if (num2 == 0)
                        {
                            result.Text = "Cannot divide by zero";

                        }
                        else
                        {
                            result.Text = (num1 / num2).ToString();
                        }
                        break;
                    }
                default:
                    result.Text = "Error";
                    return;

            }
            // Reset the input for the next calculation
            firstnum = "";
            secondnum = "";
            opert = "";
        }

    }
}