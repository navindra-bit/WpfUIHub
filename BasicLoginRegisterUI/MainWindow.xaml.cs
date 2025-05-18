using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LogAndReg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loginbutton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void regbutton_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(regusernamealr.Text))
            {


                regusernamealr.Text = "Enter a vaild UserName";
                regusernamealr.Visibility = Visibility.Visible;


            }
            else
            {
                regusernamealr.Visibility = Visibility.Collapsed;
            }
            if (regpass.Password != regconpass.Password) 
            {
                regpasswordalr.Text = "Enter a Matching password";
                regconpasswordalr.Text = "Enter a Matching password";
                regpasswordalr.Visibility= Visibility.Visible;
                regconpasswordalr.Visibility = Visibility.Visible;
            }
            else
            {
                regpasswordalr.Visibility=Visibility.Collapsed;
                regconpasswordalr.Visibility = Visibility.Collapsed;
            }
            if (!email.Text.Contains("@") && !email.Text.Contains(".")) {

                emailalr.Text = "Please , Enter a vaild Email";
                emailalr.Visibility = Visibility.Visible;
                    
            }
            else
            {
                emailalr.Visibility=Visibility.Collapsed;
            }
            int userage = Convert.ToInt32(age.Text);
            if (userage < 18)
            {
                agealr.Text = "please , Register only if your aboue 18";
                agealr.Visibility = Visibility.Visible;
            }
            else
            {
                agealr.Visibility=Visibility.Collapsed;
            }
        }

       
    }
}