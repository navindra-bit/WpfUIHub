using System.Windows;
using SampleAppLogin.Pages;

namespace SampleAppLogin
{
    /// <summary>
    /// Interaction logic for MainHome.xaml
    /// </summary>
    public partial class MainHome : Window
    {
        
        DashBoardPage DashBoardPage;
        NewBillPage NewBillPage;
        public MainHome(string userid)
        {
            InitializeComponent();
            DashBoardPage = new DashBoardPage();
            NewBillPage = new NewBillPage(userid);
            Billing.Content = DashBoardPage;
        }

        private void menu_Click(object sender, RoutedEventArgs e)
        {
            if(billbar.Visibility == Visibility.Visible)
            {
                billbar.Visibility = Visibility.Collapsed;
            }
            else
            {
                billbar.Visibility = Visibility.Visible;
            }
        }

        private void DashBoard_Click(object sender, RoutedEventArgs e)
        {
            Billing.Content = DashBoardPage;
        }

        private void NewBill_Click(object sender, RoutedEventArgs e)
        {
            Billing.Content = NewBillPage;
        }
    }
}
