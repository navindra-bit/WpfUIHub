using System.Windows;
using System.Windows.Markup;
using Microsoft.Data.SqlClient;
namespace SampleAppLogin
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
       

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            Logpage.Visibility = Visibility.Visible;
            RegPage.Visibility = Visibility.Collapsed;
            Welcomtext.Text = "Welcome Back";
        }

        private void Signup_Click(object sender, RoutedEventArgs e)
        {
            RegPage.Visibility = Visibility.Visible;
            Logpage.Visibility = Visibility.Collapsed;
            Welcomtext.Text = "Hello there!";
        }

        private void Loginbnt_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Registerbnt_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Learnmorebnt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Ourferbnt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Forgetpass_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}